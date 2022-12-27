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

        public bool AddCentre(Centre centre)
        {
            string sql = "insert into [Centres](Id, Name, Address, Phone, Details) values(@Id, @Name, @Address, @Phone, @Details)";
            var param = new
            {
                Id = centre.Id,
                Name = centre.Name,
                Address = centre.Address,
                Phone = centre.Phone,
                Details = centre.Details
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
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

        public bool DeleteCentre(string id)
        {
            string sql = "delete from [Centres] where Id='" + id + "'";
            connection.Open();
            bool result = connection.Execute(sql) == 1;
            connection.Close();
            return result;
        }

        public Centre GetCentreById(string id)
        {
            string sql = "select * from [Centres] where Id='" + id + "'";
            connection.Open();
            Centre result = connection.Query<Centre>(sql).FirstOrDefault();
            connection.Close();
            return result;
        }

        public bool UpdateCentre(Centre centre)
        {
            string sql = "update [Centres] set Name=@Name, Address=@Address, Phone=@Phone, Details=@Details where Id=@Id";
            var param = new
            {
                Id = centre.Id,
                Name = centre.Name,
                Address = centre.Address,
                Phone = centre.Phone,
                Details = centre.Details
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
    }
}
