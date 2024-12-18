
//[Index(nameof(Title),IsUnique =true)]
public class Item : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    //store
    public double? Store1 { get; set; } = 0;
    public double? Store2 { get; set; } = 0;
    public double? Store3 { get; set; } = 0;
    //Prices is fixed for each Item
    public double? Quantity1 { get; set; } = 0;
    public double? NumQuantity1InQuantity2 { get; set; } //Number
    public double? Quantity2 { get; set; } = 0;
    public double? NumQuantity2InQuantity3 { get; set; } //Number
    public double? Quantity3 { get; set; } = 0;

    public string? SortOfQuantity1 { get; set; }
    public string? SortOfQuantity2 { get; set; }
    public string? SortOfQuantity3 { get; set; }
    public double? TheSourcePrice { get; set; }
    //public bool? IsToStore { get; set; }
    //public string? ImageUrl { get; set; }
    //public string? ImageThumbnailUrl { get; set; }

}

