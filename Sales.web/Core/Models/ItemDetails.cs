namespace Sales.web.Core.Models
{
    public class ItemDetails
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string SortOfQuantity { get; set; } = null!;
        public double NumberOfQuantity { get; set; }
        public double PriceOfItem { get; set; }
        public double TotalOfPrice { get; set; }
        public int? OrderId { get; set; }
        public Order? Orders { get; set; }

    }
}
