namespace DataAPI.Models
{
    public class AdminReq
    {
        public string Search { get; set; }
    }
    public class AdminFilter
    {
        public long Id { get; set; }
        public string Search { get; set; }
    }
    public class AdminCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Details { get; set; }
    }
    public class AdminUpdateDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Details { get; set; }
    }
    public class AdminUpdatePassword
    {
        public long Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
