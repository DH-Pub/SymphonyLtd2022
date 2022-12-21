namespace DataAPI.Data.Models
{
    public class Class
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Room { get; set; }
        public bool IsBasic { get; set; }
        public double Fee { get; set; }
        public string? TeacherId { get; set; }
        public string CourseId { get; set; }
        public string? CentreId { get; set; }
    }
    /// <summary>
    /// Contain Course Name, Teacher Name
    /// </summary>
    public class ClassInfo
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Room { get; set; }
        public bool IsBasic { get; set; }
        public double Fee { get; set; }
        public string? TeacherId { get; set; }
        public string TeacherName { get; }
        public string CourseId { get; set; }
        public string CourseName { get; }
        public string? CentreId { get; set; }
        public string CentreName { get; }
    }
}
