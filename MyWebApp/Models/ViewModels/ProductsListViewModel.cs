namespace MyWebApp.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public PageInfo PageInfo { get; set; } = new();
    }
}