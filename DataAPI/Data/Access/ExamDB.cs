using Dapper;
using DataAPI.Data.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class ExamDB
    {
        public static ExamDB _object;
        /// <summary>
        /// Initiate ExamDB
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
            string sql = "SELECT e.[Id],e.[CourseId],e.[Date],e.[Details],e.[Fee],c.Name as CourseName, c.Description as CourseDescription FROM [Exams] as e JOIN [Courses] as c on e.[CourseId] = c.[Id]";
            connection.Open();
            List<ExamCourse> result = connection.Query<ExamCourse>(sql).ToList();
            connection.Close();
            return result;
        }
        public ExamCourse GetExamById(string id)
        {
            string sql = "SELECT e.[Id],e.[CourseId],e.[Date],e.[Details],e.[Fee],c.[Name] as CourseName, c.[Description] as CourseDescription FROM [Exams] as e JOIN [Courses] as c on e.[CourseId] = c.[Id] where e.[Id]='" + id + "'";
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
            bool result = false;
            connection.Open();
            try
            {
                result = connection.Execute(sql, param) == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
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
            bool result = false;
            connection.Open();
            try
            {
                result = connection.Execute(sql, param) == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return result;
        }
        public bool DeleteExam(string id)
        {
            string sql = "delete from [Exams] where [Id]='" + id + "'";
            bool result = false;
            connection.Open();
            try
            {
                result = connection.Execute(sql) == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return result;
        }

        // For ExamDetails -------------------------------------------------------------------------------------------------------
        public List<ExamDetailsWithReceipt> GetAllExamDetails()
        {
            string sql = "SELECT ed.[Id] ,ed.[RollNumber],ed.[ExamId],ed.[PaymentId],p.[ReceiptNumber],ed.[Mark] FROM [ExamDetails] as ed LEFT JOIN [Payments] as p on ed.PaymentId = p.Id";
            connection.Open();
            List<ExamDetailsWithReceipt> result = connection.Query<ExamDetailsWithReceipt>(sql).ToList();
            connection.Close();
            return result;
        }
        public ExamDetailsWithReceipt GetExamDetailsById(long id)
        {
            string sql = "SELECT ed.[Id] ,ed.[RollNumber],ed.[ExamId],ed.[PaymentId],p.[ReceiptNumber],ed.[Mark] FROM [ExamDetails] as ed LEFT JOIN [Payments] as p on ed.PaymentId = p.Id where ed.[Id]='" + id + "'";
            connection.Open();
            ExamDetailsWithReceipt result = connection.Query<ExamDetailsWithReceipt>(sql).FirstOrDefault();
            connection.Close();
            return result;
        }
        public bool CreateExamDetail(ExamDetail examDetail)
        {
            string sql = "insert into [ExamDetails](RollNumber, ExamId, PaymentId, Mark) values(@RollNumber, @ExamId, @PaymentId, @Mark)";
            var param = new
            {
                RollNumber = examDetail.RollNumber,
                ExamId = examDetail.ExamId,
                PaymentId = examDetail.PaymentId,
                Mark = examDetail.Mark
            };
            bool result = false;
            connection.Open();
            try
            {
                result = connection.Execute(sql, param) == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return result;
        }
        public bool UpdateExamDetail(ExamDetail examDetail)
        {
            string sql = "update [ExamDetails] set RollNumber=@RollNumber, ExamId=@ExamId, PaymentId=@PaymentId, Mark=@Mark where Id=@Id";
            var param = new
            {
                Id = examDetail.Id,
                RollNumber = examDetail.RollNumber,
                ExamId = examDetail.ExamId,
                PaymentId = examDetail.PaymentId,
                Mark = examDetail.Mark
            };
            bool result = false;
            connection.Open();
            try
            {
                result = connection.Execute(sql, param) == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return result;
        }
        public bool DeleteExamDetail(long id)
        {
            string sql = "delete from [ExamDetails] where [Id]='" + id + "'";
            bool result = false;
            connection.Open();
            try
            {
                result = connection.Execute(sql) == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return result;
        }

        // For Exam Results
        public List<ExamResult> GetExamResults(string rollNumber)
        {
            string sql = "SELECT ed.[Id], ed.[RollNumber], ed.[ExamId], e.[Date] as [ExamDate], ed.[PaymentId], ed.[Mark], cd.[ClassId], cl.[StartDate], cl.[Fee], c.[Name] as [CourseName] " +
                "FROM [ExamDetails] as ed " +
                "JOIN [Exams] as e on ed.ExamId = e.Id " +
                "JOIN [ClassDetails] as cd on ed.RollNumber = cd.RollNumber " +
                "JOIN [Classes] as cl on cd.ClassId = cl.Id " +
                "JOIN [Courses] as c on cl.CourseId = c.Id " +
                "WHERE ed.[RollNumber]= '" + rollNumber + "' ";
            connection.Open();
            List<ExamResult> result = connection.Query<ExamResult>(sql).ToList();
            connection.Close();
            return result;
        }
    }
}
