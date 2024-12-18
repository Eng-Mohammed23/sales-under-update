namespace Sales.web.Core.ViewModels
{
    public class ItemFormViewModel
    {
        public int? Id { get; set; }

        [Remote("AllowItem", null!, AdditionalFields = "Id", ErrorMessage = "العنصر متكرر")]
        public string Title { get; set; } = null!;
        public double? TheSourcePrice { get; set; }
        //store
        public double Store1 { get; set; } 
        public double Store2 { get; set; } 
        public double Store3 { get; set; } 
        //Prices is fixed for each Item
        public double Quantity1 { get; set; }
        public double? NumQuantity1InQuantity2 { get; set; } //Number
        public double? Quantity2 { get; set; }
        public double? NumQuantity2InQuantity3 { get; set; } //Number
        public double? Quantity3 { get; set; }
        public string? SortOfQuantity1 { get; set; }
        public string? SortOfQuantity2 { get; set; }
        public string? SortOfQuantity3 { get; set; }

    }
}
