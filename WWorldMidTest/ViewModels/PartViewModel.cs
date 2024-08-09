using Microsoft.AspNetCore.Mvc.Rendering;

namespace WWorldMidTest.ViewModels
{
    public class PartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double? Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public IEnumerable<SelectListItem>? Suppliers { get; set; }
    }

}
