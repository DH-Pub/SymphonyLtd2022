namespace Symphony.Areas.Admin.Models
{
    public class CentreModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Details { get; set; }
    }

    public class ListCentreModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<CentreModel> Data { get; set; }

    }
}
