using DataAPI.Data.Models;
using System.Data.SqlClient;
using Dapper;

namespace DataAPI.Data.Access
{
    public class TeacherDB
    {
        public static TeacherDB _object;
        /// <summary>
        /// Initiate AdminDB
        /// </summary>
        public static TeacherDB Instance
        {
            get
            {
                if (_object == null)
                {
                    _object = new TeacherDB();
                }
                return _object;
            }
        }
        private SqlConnection connection = null;
        private TeacherDB()
        {
            // Get connection string from appsettings.json file
            var appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectString = appsettings.GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }

        public bool AddTeacher(Teacher teacher)
        {
            string sql = "insert into [Teachers](Id, Name, Phone, Email, Gender, BirthDate) values(@Id, @Name, @Phone, @Email, @Gender, @BirthDate)";
            var param = new
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Phone = teacher.Phone,
                Email = teacher.Email,
                Gender = teacher.Gender,
                BirthDate = DateTime.Parse(teacher.BirthDate).Date
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }

        public List<Teacher> GetAllTeachers()
        {
            string sql = "select * from [Teachers]";
            connection.Open();
            List<Teacher> teachers = connection.Query<Teacher>(sql).ToList();
            connection.Close();
            return teachers;
        }

        public Teacher GetTeacherById(string id)
        {
            string sql = "select * from [Teachers] where Id='" + id + "'";
            connection.Open();
            Teacher teacher = connection.Query<Teacher>(sql).FirstOrDefault();
            connection.Close();
            return teacher;
        }

        public bool DeleteTeacher(string id)
        {
            string sql = "delete from [Teachers] where Id='" + id + "'";
            connection.Open();
            bool result = false;
            try
            {
                result = connection.Execute(sql) == 1;
            }
            catch
            {
                connection.Close();
                return result;
            }
            connection.Close();
            return result;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            string sql = "update [Teachers] set Name=@Name, Phone=@Phone, Email=@Email, Gender=@Gender, BirthDate=@BirthDate where Id=@Id";
            var param = new
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Phone = teacher.Phone,
                Email = teacher.Email,
                Gender = teacher.Gender,
                BirthDate = DateTime.Parse(teacher.BirthDate).Date
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
    }
}
