using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sales.web.Core.ViewModels
{
    public class OrderFormViewModel
    {
        //public int? Id { get; set; }
        //public int? SerialNumber { get; set; }
        public double Payment { get; set; }
        public double TheRest { get; set; }
        public double Total { get; set; }

        public int? ClientId { get; set; }
        public IEnumerable<SelectListItem>? Clients { get; set; }
        public string? ClientName { get; set; }
        public IList<string> Title { get; set; } = new List<string>();
        public IList<string> SortOfQuantity { get; set; } = new List<string>();
        public IList<int> ThePrice { get; set; } = new List<int>();
        public IList<int> Number { get; set; } = new List<int>();
        public IList<double> SortOfNum { get; set; } = new List<double>();
        public IList<int> TotalOfPrice { get; set; } = new List<int>();
        public bool ToStore { get; set; }

        //public List<int>? SelectedCategories { get; set; } = new List<int>();
        //public IEnumerable<SelectListItem>? Categories { get; set;

        public IList<int> SelectedItems { get; set; } = new List<int>();
        public IEnumerable<SelectListItem>? Items { get; set; }
        public string? Note { get; set; }
        public double AfterDiscount { get; set; }
        public double Discount { get; set; }
    }
}
