using MyWebApp.Models.ViewModels;
using MyWebApp.Models;

public class ProductsListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    public PageInfo PageInfo { get; set; } = new();
    public string? CurrentCategory { get; set; }
}