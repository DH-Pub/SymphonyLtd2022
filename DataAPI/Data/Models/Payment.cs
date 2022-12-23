namespace DataAPI.Data.Models
{
    public class Payment
    {
        public long Id { get; set; }
        public string ReceiptNumber { get; set; }
        public string FromAccount { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
    }
}
