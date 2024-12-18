namespace Sales.web.Core.Models
{
    public class Account : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Note { get; set; }
        public double? Price { get; set; }
        public string? NumberOfAccount { get; set; }
    }
}
