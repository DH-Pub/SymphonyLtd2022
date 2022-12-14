using System.ComponentModel.DataAnnotations;

namespace Symphony.Areas.Admin.Models
{
    public class AdminModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public string Details { get; set; }
    }
    public class AdminCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public string Details { get; set; }
    }
    /// <summary>
    /// Display Admins (no passwords)
    /// </summary>
    public class AdminShowModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public string Details { get; set; }
    }
    /// <summary>
    /// For receiving api result for AdminShowModel
    /// </summary>
    public class AdminListApiShow
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<AdminShowModel> Data { get; set; }
    }
    public class AdminApiShow
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public AdminShowModel Data { get; set; }
    }


    /// <summary>
    /// Model used to Login (send to API)
    /// </summary>
    public class AdminLoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }


    /// <summary>
    /// To get token
    /// </summary>
    public class AdminResultModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
    /// <summary>
    /// Recieve result when login include token
    /// </summary>
    public class AdminApiResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public AdminResultModel Data { get; set; }
    }
}
