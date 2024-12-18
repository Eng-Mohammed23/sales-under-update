namespace Sales.web.Core.ViewModels
{
    public class AccountViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string? Note { get; set; }
        public double Price { get; set; } 
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedOn { get; set; }
    }
}
