
//[Index(nameof(PhoneNumber), IsUnique = true)]
//[Index(nameof(Email), IsUnique = true)]
//[Index(nameof(FullName), IsUnique = true)]
public class Client : BaseModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;

    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SortOfQuality { get; set; }
    public bool? IsBlackListed { get; set; }
    public double Account { get; set; }
    public ICollection<Order>? orders = new List<Order>();
    //public ItemDetails DetailsOfItem { get; set; }
}