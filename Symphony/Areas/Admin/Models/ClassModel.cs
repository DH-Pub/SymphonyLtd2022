using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Symphony.Areas.Admin.Models
{
    public class ClassModel
    {
        public string Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime EndDate { get; set; }
        public string? Room { get; set; }
        public bool IsBasic { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100_000)]
        public double Fee { get; set; }
        public string? TeacherId { get; set; }
        [Required]
        public string CourseId { get; set; }
        public string? CentreId { get; set; }
    }
    public class ClassInfoModel
    {
        public string Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime EndDate { get; set; }
        public string? Room { get; set; }
        public bool IsBasic { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100_000)]
        public double Fee { get; set; }
        public string? TeacherId { get; set; }
        [DisplayName("Teacher")]
        public string TeacherName { get; }
        public string CourseId { get; set; }
        [DisplayName("Course")]
        public string CourseName { get; }
        public string? CentreId { get; set; }
        [DisplayName("Centre")]
        public string CentreName { get; }
    }
    public class ClassInfoListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ClassInfoModel> Data { get; set; }
    }
    public class ClassInfoApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ClassInfoModel Data { get; set; }
    }

    // For ClassDetails ----------------------------------------------------------------
    public class ClassDetailModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Student RollNumber")]
        public string RollNumber { get; set; }
        [Required]
        public string ClassId { get; set; }
        public long? PaymentId { get; set; }
        public string? Details { get; set; }
        [DisplayName("Pass")]
        public bool IsPass { get; set; }
        [DisplayName("Lab Session")]
        public bool IsLabSession { get; set; }
    }
    public class ClassDetailWithReceiptModel
    {
        public long Id { get; set; }
        public string RollNumber { get; set; }
        public string ClassId { get; set; }
        public long? PaymentId { get; set; }
        public string ReceiptNumber { get; set; }
        public string? Details { get; set; }
        [DisplayName("Pass")]
        public bool IsPass { get; set; }
        [DisplayName("Lab Session")]
        public bool IsLabSession { get; set; }
    }
    public class ClassDetailWithReceiptListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ClassDetailWithReceiptModel> Data { get; set; }
    }
    public class ClassDetailWithReceiptApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ClassDetailWithReceiptModel Data { get; set; }
    }
}