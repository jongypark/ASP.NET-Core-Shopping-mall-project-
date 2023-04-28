namespace MyWebApp.Models
{
    public interface IMyDBRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product p);

        void CreateProduct(Product p);

        void DeleteProduct(Product p);
    }
}