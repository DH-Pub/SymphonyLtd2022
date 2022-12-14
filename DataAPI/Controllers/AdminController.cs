﻿using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Main")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationSettings _applicationSettings;
        public AdminController(IOptions<ApplicationSettings> applicationSettings)
        {
            this._applicationSettings = applicationSettings.Value;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(AdminLogin model)
        {
            ResultInfo resultInfo = new ResultInfo();
            var admin = AdminDB.Instance.GetAdminByEmail(model.Email);
            if (admin == null)
            {
                FirstAdmin(); // generate admin if there are no main
                resultInfo.Message = "admin does not exist";
                return Ok(resultInfo);
            }
            bool match = CheckPassword(model.Password, admin);
            if (!match)
            {
                resultInfo.Message = "admin or password is incorrect";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;

            // token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", admin.Email),
                    new Claim(ClaimTypes.Role, admin.Role) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);
            // -------------------

            var adminResult = new AdminResult();
            adminResult.Id = admin.Id;
            adminResult.Name = admin.Name;
            adminResult.Email = admin.Email;
            adminResult.Token = encrypterToken;

            resultInfo.Data = adminResult;
            return Ok(resultInfo);
        }
        [HttpGet]
        public IActionResult GetAdmin(long id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = true;
            var admin = AdminDB.Instance.GetAdminById(id);
            resultInfo.Data = admin;
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult ShowAdmins(AdminFilter filter)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = true;
            string search = (filter != null) ? filter.Search : string.Empty;
            var admins = AdminDB.Instance.GetAllAdmins(search);
            resultInfo.Data = admins.Select(a => new { a.Id, a.Name, a.Email, a.Role, a.Details }).ToList(); // don't return password
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateAdmin(AdminCreate adminCreate)
        {
            ResultInfo resultInfo = new ResultInfo();
            PasswordHashing pwd = HashPass(adminCreate.Password);
            Admin admin = new Admin
            {
                Name = adminCreate.Name,
                Email = adminCreate.Email,
                PasswordSalt = pwd.PasswordSalt,
                PasswordHash = pwd.PasswordHash,
                Role = adminCreate.Role,
                Details = adminCreate.Details,
            };
            resultInfo.Status = AdminDB.Instance.CreateAdmin(admin);
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdateAdminDetails(AdminUpdateDetails adminUpdate)
        {
            ResultInfo resultInfo = new ResultInfo();
            Admin admin = new Admin
            {
                Id = adminUpdate.Id,
                Name = adminUpdate.Name,
                Email = adminUpdate.Email,
                Role = adminUpdate.Role,
                Details = adminUpdate.Details
            };
            resultInfo.Status = AdminDB.Instance.UpdateAdminDetails(admin);
            return Ok(resultInfo);
        }

        [HttpPost]
        public IActionResult UpdateAdminPassword(AdminUpdatePassword adminPwd)
        {
            ResultInfo resultInfo = new ResultInfo();
            PasswordHashing pwd = HashPass(adminPwd.Password);
            Admin admin = new Admin
            {
                Id = adminPwd.Id,
                PasswordHash = pwd.PasswordHash,
                PasswordSalt = pwd.PasswordSalt
            };
            resultInfo.Status = AdminDB.Instance.UpdateAdminPassword(admin);
            return Ok(resultInfo);
        }
        /// <summary>
        /// Check if the password is correct
        /// </summary>
        /// <param name="password"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        private bool CheckPassword(string password, Data.Models.Admin admin)
        {
            bool result;
            using (HMACSHA512? hmac = new HMACSHA512(admin.PasswordSalt))
            {
                var compute = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(admin.PasswordHash);
            }
            return result;
        }

        /// <summary>
        /// Hashing password when creating
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private PasswordHashing HashPass(string password)
        {
            var pass = new PasswordHashing();
            using (HMACSHA512? hmac = new HMACSHA512())
            {
                pass.PasswordSalt = hmac.Key;
                pass.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return pass;
        }
        /// <summary>
        /// If there are no Main Admins
        /// </summary>
        /// <returns></returns>
        private bool FirstAdmin()
        {
            bool result = false;
            var main = AdminDB.Instance.GetAllAdmins().Where(x => x.Role == "Main").FirstOrDefault();
            if (main == null)
            {
                var admin = new Data.Models.Admin { Name = "Main Admin", Email = "main@email.com", Role = "Main" };
                var pass = HashPass("password");
                admin.PasswordSalt = pass.PasswordSalt;
                admin.PasswordHash = pass.PasswordHash;
                result = AdminDB.Instance.CreateAdmin(admin);
            }
            return result;
        }
    }
}
