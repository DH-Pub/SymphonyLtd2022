using Dapper;
using DataAPI.Data.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class ClassDB
    {
        public static ClassDB _object;
        public static ClassDB Instance
        {
            get
            {
                if (_object == null) _object = new ClassDB();
                return _object;
            }
        }
        private SqlConnection connection = null;
        private ClassDB()
        {
            string connectString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }
        public List<Class> GetAllClasses()
        {
            string sql = "SELECT cl.[Id],cl.[StartDate],cl.[EndDate],cl.[Room],cl.[IsBasic],cl.[Fee] " +
                ",cl.[TeacherId],t.[Name] as [TeacherName],cl.[CourseId],c.[Name] as [CourseName],cl.[CentreId],cen.[Name] as [CentreName] " +
                "FROM [Classes] as cl JOIN [Courses] as c on cl.[CourseId] = c.[Id] " +
                "LEFT JOIN [Centres] as cen on cl.[CentreId] = cen.[Id] LEFT JOIN [Teachers] as t on cl.[TeacherId] = t.[Id]";
            connection.Open();
            List<Class> result = connection.Query<Class>(sql).ToList();
            connection.Close();
            return result;
        }
        public Class GetClassById(string id)
        {
            string sql = "SELECT cl.[Id],cl.[StartDate],cl.[EndDate],cl.[Room],cl.[IsBasic],cl.[Fee] " +
                ",cl.[TeacherId],t.[Name] as [TeacherName],cl.[CourseId],c.[Name] as [CourseName],cl.[CentreId],cen.[Name] as [CentreName] " +
                "FROM [Classes] as cl JOIN [Courses] as c on cl.[CourseId] = c.[Id] " +
                "LEFT JOIN [Centres] as cen on cl.[CentreId] = cen.[Id] LEFT JOIN [Teachers] as t on cl.[TeacherId] = t.[Id] WHERE cl.[Id]='" + id + "'";
            connection.Open();
            Class result = connection.Query<Class>(sql).FirstOrDefault();
            connection.Close();
            return result;
        }
        public bool CreateClass(Class model)
        {
            string sql = "insert into [Classes](Id, StartDate, EndDate, Room, IsBasic, Fee, TeacherId, CourseId, CentreId) values(@Id, @StartDate, @EndDate, @Room, @IsBasic, @Fee, @TeacherId, @CourseId, @CentreId)";
            var param = new
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Room = model.Room,
                IsBasic = model.IsBasic,
                Fee = model.Fee,
                TeacherId = model.TeacherId,
                CourseId = model.CourseId,
                CentreId = model.CentreId,
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
        public bool UpdateClass(Class model)
        {
            string sql = "update [Classes] set StartDate=@StartDate, EndDate=@EndDate, Room=@Room, IsBasic=@IsBasic, Fee=@Fee, TeacherId=@TeacherId, CourseId=@CourseId, CentreId=@CentreId where Id=@Id";
            var param = new
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Room = model.Room,
                IsBasic = model.IsBasic,
                Fee = model.Fee,
                TeacherId = model.TeacherId,
                CourseId = model.CourseId,
                CentreId = model.CentreId,
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
        public bool DeleteClass(string id)
        {
            string sql = "delete from [Classes] where [Id]='" + id + "'";
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

        // For ClassDetails -----------------------------------------------------------------------------------
        public List<ClassDetailWithReceipt> GetAllClassDetails()
        {
            string sql = "SELECT cd.[Id],[RollNumber],[ClassId],[PaymentId],[ReceiptNumber],cd.[Details],[IsPass],[IsLabSession] " +
                "FROM [ClassDetails] as cd LEFT JOIN [Payments] as p on cd.PaymentId=p.Id ";
            connection.Open();
            List<ClassDetailWithReceipt> result = connection.Query<ClassDetailWithReceipt>(sql).ToList();
            connection.Close();
            return result;
        }
        public ClassDetailWithReceipt GetClassDetailById(long id)
        {
            string sql = "SELECT cd.[Id],[RollNumber],[ClassId],[PaymentId],[ReceiptNumber],cd.[Details],[IsPass],[IsLabSession] " +
                "FROM [ClassDetails] as cd LEFT JOIN [Payments] as p on cd.PaymentId=p.Id WHERE cd.[Id]='" + id + "'";
            connection.Open();
            ClassDetailWithReceipt result = connection.Query<ClassDetailWithReceipt>(sql).FirstOrDefault();
            connection.Close();
            return result;
        }
        public bool CreateClassDetail(ClassDetail classDetail)
        {
            string sql = "insert into [ClassDetails](RollNumber, ClassId, PaymentId, Details, IsPass, IsLabSession) values(@RollNumber, @ClassId, @PaymentId, @Details, @IsPass, @IsLabSession)";
            var param = new
            {
                RollNumber = classDetail.RollNumber,
                ClassId = classDetail.ClassId,
                PaymentId = classDetail.PaymentId,
                Details = classDetail.Details,
                IsPass = classDetail.IsPass,
                IsLabSession = classDetail.IsLabSession,
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
        public bool UpdateClassDetail(ClassDetail classDetail)
        {
            string sql = "update [ClassDetails] set RollNumber=@RollNumber, ClassId=@ClassId, PaymentId=@PaymentId, Details=@Details, IsPass=@IsPass, IsLabSession=@IsLabSession where Id=@Id";
            var param = new
            {
                Id = classDetail.Id,
                RollNumber = classDetail.RollNumber,
                ClassId = classDetail.ClassId,
                PaymentId = classDetail.PaymentId,
                Details = classDetail.Details,
                IsPass = classDetail.IsPass,
                IsLabSession = classDetail.IsLabSession,
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
        public bool DeleteClassDetail(long id)
        {
            string sql = "delete from [ClassDetails] where [Id]='" + id + "'";
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
    }
}
