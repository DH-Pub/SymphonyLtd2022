using System.ComponentModel.DataAnnotations;

namespace Symphony.Areas.Admin.Models
{
    public class ExamModel
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, double.MaxValue)]
        public double Fee { get; set; }
    }
    /// <summary>
    /// show exam information with courses
    /// </summary>
    public class ExamCourseModel
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, double.MaxValue)]
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
}
