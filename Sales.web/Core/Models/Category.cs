
namespace Sales.web.Core.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        //public ICollection<Item> items = new List<Item>();
    }
}
