namespace Symphony.Areas.Admin.Models
{
    public class About
    {
        public int Number { get; set; }
        public string Description { get; set; }
    }
    public class AboutListApiShow
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<About> Data { get; set; }
    }

    public class AboutApiResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public About Data { get; set; }
    }
}
