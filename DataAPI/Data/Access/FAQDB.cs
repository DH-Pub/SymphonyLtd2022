using System.Data.SqlClient;
using Dapper;
using DataAPI.Data.Models;
using DataAPI.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class FAQDB
    {
        public static FAQDB _object;
        public static FAQDB Instance
        {
            get
            {
                if (_object == null)
                {
                    _object = new FAQDB();
                }
                return _object;
            }
        }
        private SqlConnection connection = null;
        private FAQDB()
        {
            // Get connection string from appsettings.json file
            var appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectString = appsettings.GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }
        public bool CreateFAQ(FAQ faq)
        {
            string sql = "insert into [FAQs](Number, Question, Answer) values(@Number, @Question, @Answer)";
            var param = new
            {
                Number = faq.Number,
                Question = faq.Question,
                Answer = faq.Answer,
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }

        public bool DeleteFAQ(int Number)
        {
            string sql = "delete from [FAQs] where [Number]='" + Number + "'";
            connection.Open();
            bool result = connection.Execute(sql) == 1;
            connection.Close();
            return result;
        }

        public bool UpdateFAQDetails(FAQ faq)
        {
            string sql = "update [FAQs] set  Question=@Question,  Answer=@Answer where Number=@Number";
            var param = new
            {
                Number = faq.Number,
                Question = faq.Question,
                Answer = faq.Answer,
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }

        public FAQ GetFAQByNumber(int Number)
        {
            string sql = "select * from [FAQs] where [Number]='" + Number + "'";
            connection.Open();
            FAQ faq = connection.Query<FAQ>(sql).FirstOrDefault();
            connection.Close();
            return faq;
        }

        public List<FAQ> GetAllFAQs(string keySearch = "")
        {
            string sql = "select * from [FAQs]";
            if (!string.IsNullOrWhiteSpace(keySearch))
            {
                sql += " where Question like '" + keySearch + "' or Answer like N'%" + keySearch + "%'";
            }
            connection.Open();
            List<FAQ> result = connection.Query<FAQ>(sql).ToList();
            connection.Close();
            return result;
        }
    }
}
