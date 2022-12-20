namespace DataAPI.Data.Models
{
    public class Exam
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public double Fee { get; set; }
    }
    /// <summary>
    /// show exam with course name
    /// </summary>
    public class ExamCourse
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public double Fee { get; set; }
    }
}
