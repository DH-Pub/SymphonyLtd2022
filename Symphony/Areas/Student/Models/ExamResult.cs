using System.ComponentModel.DataAnnotations;

namespace Symphony.Areas.Student.Models
{
    public class ExamResult
    {
        public long Id { get; set; }
        public string RollNumber { get; set; }
        public string ExamId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExamDate { get; set; }
        public float? Mark { get; set; }
        public string ClassId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Fee { get; set; }
        public string CourseName { get; set; }
    }
    public class ExamResultListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ExamResult> Data { get; set; }
    }
}
