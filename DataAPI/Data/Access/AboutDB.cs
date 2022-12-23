using Dapper;
using DataAPI.Data.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class AboutDB
    {
        public static AboutDB _object;
        public static AboutDB Instance
        {
            get
            {
                if (_object == null)
                {
                    _object = new AboutDB();
                }
                return _object;
            }
        }
        private SqlConnection connection = null;
        private AboutDB()
        {
            // Get connection string from appsettings.json file
            var appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectString = appsettings.GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }

        public bool CreateAbout(About abt)
        {
            string sql = "insert into [AboutUs](Number, Description) values(@Number, @Description)";
            var param = new
            {
                Number = abt.Number,
                Description = abt.Description,
                
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }

        public bool DeleteAbout(int Number)
        {
            string sql = "delete from [AboutUs] where [Number]='" + Number + "'";
            connection.Open();
            bool result = connection.Execute(sql) == 1;
            connection.Close();
            return result;
        }

        public bool UpdateAboutDetails(About abt)
        {
            string sql = "update [AboutUs] set  Description=@Description where Number=@Number";
            var param = new
            {
                Number = abt.Number,
                Description = abt.Description,
                
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }

        public About GetAboutByNumber(int Number)
        {
            string sql = "select * from [AboutUs] where [Number]='" + Number + "'";
            connection.Open();
            About abt = connection.Query<About>(sql).FirstOrDefault();
            connection.Close();
            return abt;
        }

        public List<About> GetAllAbouts(string keySearch = "")
        {
            string sql = "select * from [AboutUs]";
            if (!string.IsNullOrWhiteSpace(keySearch))
            {
                sql += " where Number like '" + keySearch + "' or Description like N'%" + keySearch + "%'";
            }
            connection.Open();
            List<About> result = connection.Query<About>(sql).ToList();
            connection.Close();
            return result;
        }
    }
}
