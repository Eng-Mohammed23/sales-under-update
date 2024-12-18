namespace Sales.web.Core.ViewModels
{
    public class ClientFormViewModel
    {
        public int? Id { get; set; }

        [Remote("AllowItem", null!, AdditionalFields = "Id", ErrorMessage = "العنصر متكرر")]
        public string FullName { get; set; } = null!;

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? SortOfQuality { get; set; }

        public double Account { get; set; }
    }
}
