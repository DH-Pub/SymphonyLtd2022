using System.ComponentModel.DataAnnotations;

namespace Symphony.Areas.Admin.Models
{
    public class PaymentModel
    {
        public long Id { get; set; }
        [Required]
        public string ReceiptNumber { get; set; }
        [Required]
        public string FromAccount { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100_000_000)]
        public double Amount { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
        public string Details { get; set; }
    }
    public class PaymentListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<PaymentModel> Data { get; set; }
    }
    public class PaymentApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public PaymentModel Data { get; set; }
    }
}
