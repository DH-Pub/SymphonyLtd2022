using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Symphony.Areas.Admin.Models
{
    public class ExamModel
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Course ID")]
        public string CourseId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
        public string Details { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100_000)]
        public double Fee { get; set; }
    }
    /// <summary>
    /// show exam information with courses
    /// </summary>
    public class ExamCourseModel
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Course ID")]
        public string CourseId { get; set; }
        [DisplayName("Name of Course")]
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
        public string Details { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100_000)]
        public double Fee { get; set; }
    }
    /// <summary>
    /// For receiving api result for list of ExamCourseModel
    /// </summary>
    public class ExamCourseListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ExamCourseModel> Data { get; set; }
    }
    /// <summary>
    /// For receiving api result for ExamCourseModel
    /// </summary>
    public class ExamCourseApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ExamCourseModel Data { get; set; }
    }

    // For ExamDetails -----------------------------------------------------------------------------
    public class ExamDetailModel
    {
        public long Id { get; set; }
        [Required]
        public string RollNumber { get; set; }
        [Required]
        public string ExamId { get; set; }
        public long? PaymentId { get; set; }
        [Range(0, 100)]
        public float? Mark { get; set; }
    }
    /// <summary>
    /// Show exam details with receipt number
    /// </summary>
    public class ExamDetailsWithReceipt
    {
        public long Id { get; set; }
        public string RollNumber { get; set; }
        public string ExamId { get; set; }
        public long PaymentId { get; set; }
        public string ReceiptNumber { get; set; }
        [Range(0, 100)]
        public float Mark { get; set; }
    }
    /// <summary>
    /// List Api of ExamDetailsWithReceipt
    /// </summary>
    public class ExamDetailsWithReceiptListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ExamDetailsWithReceipt> Data { get; set; }
    }
    /// <summary>
    /// For receiving api for ExamDetailsWithReceipt
    /// </summary>
    public class ExamDetailsWithReceiptApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ExamDetailsWithReceipt Data { get; set; }
    }
}
