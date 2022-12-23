using Microsoft.Build.Framework;
using System.ComponentModel;

namespace Symphony.Areas.Admin.Models
{
    public class CourseModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("New Course")]
        public bool IsNew { get; set; } = false;
    }
    public class CourseListApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<CourseModel> Data { get; set; }
    }
    public class CourseApi
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public CourseModel Data { get; set; }
    }
}
