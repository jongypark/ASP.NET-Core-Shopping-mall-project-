namespace MyWebApp.Models
{
    public class MyDBRepository : IMyDBRepository
    {
        private MyDbContext _dbContext;

        public MyDBRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> Products => _dbContext.Products;
    }
}