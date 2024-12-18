using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sales.web.Core.ViewModels
{
    public class AddItemViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ItemId { get; set; }
        public int? SelectClientUp { get; set; }
        public string? SortOfQuantity { get; set; }
        public double ThePrice { get; set; }
        public double Number { get; set; }
        public int NumOfStore { get; set; } = 1;
        public double TotalOfPrice { get; set; }
        public double? TheSourcePrice { get; set; }
        public IEnumerable<SelectListItem>? Items { get; set; }
        public IEnumerable<SelectListItem>? Clients { get; set; }
    }
}
