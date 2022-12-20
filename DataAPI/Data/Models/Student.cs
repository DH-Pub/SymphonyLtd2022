namespace DataAPI.Data.Models
{
    public class Student
    {
        public string RollNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }
    }

    public class StudentToGet
    {
        public string RollNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Image { get; set; }
    }

    public class StudentToDelete
    {
        public string RollNumber { get; set; }
    }
}
