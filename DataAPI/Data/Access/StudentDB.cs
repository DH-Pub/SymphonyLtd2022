using Dapper;
using DataAPI.Data.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class StudentDB
    {
        public static StudentDB _object;
        /// <summary>
        /// Initiate StudentDB
        /// </summary>
        public static StudentDB Instance
        {
            get
            {
                if (_object == null)
                {
                    _object = new StudentDB();
                }
                return _object;
            }
        }
        private SqlConnection connection = null;
        private StudentDB()
        {
            // Get connection string from appsettings.json file
            var appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectString = appsettings.GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }

        public bool AddStudent(Student student)
        {
            string sql = "insert into [Students](RollNumber, FullName, Address, Phone, Email, Gender, BirthDate, Image) values(@RollNumber, @FullName, @Address, @Phone, @Email, @Gender, @BirthDate, @Image)";
            var param = new
            {
                RollNumber = student.RollNumber,
                FullName = student.FullName,
                Address = student.Address,
                Phone = student.Phone,
                Email = student.Email,
                Gender = student.Gender,
                BirthDate = DateTime.Parse(student.BirthDate).Date,
                Image = student.ImageName,
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }

        public List<StudentToGet> GetAllStudents()
        {
            string sql = "select * from [Students]";
            connection.Open();
            List<StudentToGet> result = connection.Query<StudentToGet>(sql).ToList();
            connection.Close();
            return result;
        }

        public bool DeleteStudent(string rollNo)
        {
            string sql = "delete from [Students] where RollNumber=@RollNumber";
            var param = new
            {
                RollNumber = rollNo
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
    }
}
