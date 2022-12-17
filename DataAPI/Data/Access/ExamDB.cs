using Dapper;
using DataAPI.Data.Models;
using Microsoft.AspNetCore.Connections.Features;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class ExamDB
    {
        public static ExamDB _object;
        /// <summary>
        /// Initiate AdminDB
        /// </summary>
        public static ExamDB Instance
        {
            get
            {
                if (_object == null)
                {
                    _object = new ExamDB();
                }
                return _object;
            }
        }
        private SqlConnection connection = null;
        private ExamDB()
        {
            // Get connection string from appsettings.json file
            var appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectString = appsettings.GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }
        public List<ExamCourse> GetAllExamsWithCourses()
        {
            string sql = "SELECT e.[Id],e.[CourseId],e.[Date],e.[Details],e.[Fee],c.Name as CourseName, c.Description as CourseDescription\r\nFROM [Exams] as e JOIN [Courses] as c on e.[CourseId] = c.[Id]";
            connection.Open();
            List<ExamCourse> result = connection.Query<ExamCourse>(sql).ToList();
            connection.Close();
            return result;
        }
        public ExamCourse GetExamById(string id)
        {
            string sql = "SELECT e.[Id],e.[CourseId],e.[Date],e.[Details],e.[Fee],c.[Name] as CourseName, c.[Description] as CourseDescription\r\nFROM [Exams] as e JOIN [Courses] as c on e.[CourseId] = c.[Id] where e.[Id]='" + id + "'";
            connection.Open();
            ExamCourse exam = connection.Query<ExamCourse>(sql).FirstOrDefault();
            connection.Close();
            return exam;
        }
        public bool CreateExam(Exam exam)
        {
            string sql = "insert into [Exams](Id, CourseId, Date, Details, Fee) values(@Id, @CourseId, @Date, @Details, @Fee)";
            var param = new
            {
                Id = exam.Id,
                CourseId = exam.CourseId,
                Date = exam.Date,
                Details = exam.Details,
                Fee = exam.Fee
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
        public bool UpdateExam(Exam exam)
        {
            string sql = "update [Exams] set CourseId=@CourseId, Date=@Date, Details=@Details, Fee=@Fee where Id=@Id";
            var param = new
            {
                Id = exam.Id,
                CourseId = exam.CourseId,
                Date = exam.Date,
                Details = exam.Details,
                Fee = exam.Fee
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
        public bool DeleteExam(string id)
        {
            string sql = "delete from [Exams] where [Id]='" + id + "'";
            connection.Open();
            bool result = connection.Execute(sql) == 1;
            connection.Close();
            return result;
        }
    }
}
