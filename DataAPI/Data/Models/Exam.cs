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

    // ------------------------------------------------------------------------------------
    /// <summary>
    /// For ExamDetails table
    /// </summary>
    public class ExamDetail
    {
        public long Id { get; set; }
        public string RollNumber { get; set; }
        public string ExamId { get; set; }
        public long? PaymentId { get; set; }
        public float? Mark { get; set; }
    }
    /// <summary>
    /// ExamDetails with ReceiptNumber From Payments
    /// </summary>
    public class ExamDetailsWithReceipt
    {
        public long Id { get; set; }
        public string RollNumber { get; set; }
        public string ExamId { get; set; }
        public long PaymentId { get; set; }
        public string ReceiptNumber { get; set; }
        public float Mark { get; set; }
    }

    // -------------------------------------------------------------------------------------------
    /// <summary>
    /// Show result of exam through RollNumber input
    /// </summary>
    public class ExamResult
    {
        public long Id { get; set; }
        public string RollNumber { get; set; }
        public string ExamId { get; set; }
        public string ExamDate { get; set; }
        public float? Mark { get; set; }
        public string ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public double Fee { get; set; }
        public string CourseName { get; set; }
    }
}
