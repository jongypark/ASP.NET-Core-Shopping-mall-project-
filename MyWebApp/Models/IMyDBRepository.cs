namespace MyWebApp.Models
{
    public interface IMyDBRepository
    {
        IQueryable<Product> Products { get; }
    }
}