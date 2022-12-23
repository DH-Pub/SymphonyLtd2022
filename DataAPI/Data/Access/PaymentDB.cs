using Dapper;
using DataAPI.Data.Models;
using System.Data.SqlClient;

namespace DataAPI.Data.Access
{
    public class PaymentDB
    {
        public static PaymentDB _object;
        public static PaymentDB Instance
        {
            get
            {
                if (_object == null) _object = new PaymentDB();
                return _object;
            }
        }
        private SqlConnection connection = null;
        private PaymentDB()
        {
            string connectString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DB"];
            connection = new SqlConnection(connectString);
        }
        public List<Payment> GetAllPayments()
        {
            string sql = "select * from [Payments]";
            connection.Open();
            List<Payment> result = connection.Query<Payment>(sql).ToList();
            connection.Close();
            return result;
        }
        public Payment GetPaymentById(long id)
        {
            string sql = "select * from [Payments] where Id='" + id + "'";
            connection.Open();
            Payment payment = connection.Query<Payment>(sql).FirstOrDefault();
            connection.Close();
            return payment;
        }
        public bool CreatePayment(Payment payment)
        {
            string sql = "insert into [Payments](ReceiptNumber, FromAccount, Amount, Date, Details) values(@ReceiptNumber, @FromAccount, @Amount, @Date, @Details)";
            var param = new
            {
                ReceiptNumber = payment.ReceiptNumber,
                FromAccount = payment.FromAccount,
                Amount = payment.Amount,
                Date = payment.Date,
                Details = payment.Details,
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
        public bool UpdatePayment(Payment payment)
        {
            string sql = "update [Payments] set ReceiptNumber=@ReceiptNumber, FromAccount=@FromAccount, Amount=@Amount, Date=@Date, Details=@Details where Id=@Id";
            var param = new
            {
                Id = payment.Id,
                ReceiptNumber = payment.ReceiptNumber,
                FromAccount = payment.FromAccount,
                Amount = payment.Amount,
                Date = payment.Date,
                Details = payment.Details,
            };
            connection.Open();
            bool result = connection.Execute(sql, param) == 1;
            connection.Close();
            return result;
        }
        public bool DeletePayment(long id)
        {
            string sql = "delete from [Payments] where [Id]='" + id + "'";
            connection.Open();
            bool result = connection.Execute(sql) == 1;
            connection.Close();
            return result;
        }
    }
}
