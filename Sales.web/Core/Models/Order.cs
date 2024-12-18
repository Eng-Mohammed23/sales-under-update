namespace Sales.web.Core.Models
{
    public class Order : BaseModel
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public double Payment { get; set; }
        public double TheRest { get; set; }
        public double Total { get; set; }
        public string? Note { get; set; }
        public double? AfterDiscount { get; set; }
        public double? Discount { get; set; }
        public int? ClientId { get; set; } = 0;
        public Client? Client { get; set; }

        public ICollection<ItemDetails> DetailsOfItem { get; set; } = new List<ItemDetails>();
    }
}
