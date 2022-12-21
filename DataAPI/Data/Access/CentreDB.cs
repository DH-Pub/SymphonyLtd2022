using System.Data.SqlClient;
using Dapper;
using DataAPI.Data.Models;
namespace DataAPI.Data.Access
{
    public class CentreDB
    {
        public static CentreDB _object;
        /// <summary>
        /// Initiate AdminDB
        /// </summary>
        public static CentreDB Instance
        {
            get
            {
                if (_object == null)
                {
                    _object = new CentreDB();
                }
                return _object;
            }
        }
        private SqlConnection connection = null;
        private CentreDB()
        {
            // Get connection string from appsettings.json file
            var appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectString = appsettings.GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }

        public List<Centre> GetAllCentres(string keySearch = "")
        {
            string sql = "select * from [Centres]";
            if (!string.IsNullOrWhiteSpace(keySearch))
            {
                sql += " where Id like '" + keySearch + "' or Name like N'%" + keySearch + "%'";
            }
            connection.Open();
            List<Centre> result = connection.Query<Centre>(sql).ToList();
            connection.Close();
            return result;
        }
    }
}
