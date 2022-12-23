using System.ComponentModel.DataAnnotations;
namespace Symphony.Areas.Admin.Models
{
    public class FAQ
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

    }

    public class FAQCreateModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        

    }

    public class FAQListApiShow { 
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<FAQ> Data { get; set; }
    }

    public class FAQResultModel
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Token { get; set; }
    }

    public class FAQApiResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public FAQ Data { get; set; }
    }
}
