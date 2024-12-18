namespace Sales.web.Core.ViewModels
{
    public class OrderViewModel
    {
        public double Payment { get; set; }
        public double TheRest { get; set; }
        public double Total { get; set; }
        public double? AfterDiscount { get; set; }
        public double? Discount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public IEnumerable<ItemDetails>? DetailsOfItem { get; set; } = new List<ItemDetails>();
    }
}
