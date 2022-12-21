using Dapper;
using DataAPI.Data.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class CourseDB
    {
        public static CourseDB _object;
        public static CourseDB Instance
        {
            get
            {
                if (_object == null) _object = new CourseDB();
                return _object;
            }
        }
        private SqlConnection connection = null;
        private CourseDB()
        {
            string connectString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }
        public List<Course> GetAllCourses()
        {
            string sql = "select * from [Courses]";
            connection.Open();
            List<Course> list = connection.Query<Course>(sql).ToList();
            connection.Close();
            return list;
        }
        public Course GetCourse(string id)
        {
            string sql = "select * from [Courses] where [Id]='" + id + "'";
            connection.Open();
            Course course = connection.Query<Course>(sql).FirstOrDefault();
            connection.Close();
            return course;
        }
        public bool CreateCourse(Course course)
        {
            string sql = "insert into [Courses](Id, Name, Description, IsNew) values(@Id, @Name, @Description, @IsNew)";
            var param = new
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                IsNew = course.IsNew
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
        public bool UpdateCourse(Course course)
        {
            string sql = "update [Courses] set Name=@Name, Description=@Description, IsNew=@IsNew where Id=@Id";
            var param = new
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                IsNew = course.IsNew
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
        public bool DeleteCourse(string id)
        {
            string sql = "delete from [Courses] where [Id]='" + id + "'";
            connection.Open();
            bool result = connection.Execute(sql) == 1;
            connection.Close();
            return result;
        }
    }
}
