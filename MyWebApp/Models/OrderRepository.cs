using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public class OrderRepository : IOrderRepository
    {
        private MyDbContext _dbContext;

        public OrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Order> Orders => _dbContext.Orders.Include(o => o.Items).ThenInclude(p => p.Product);

        public void SaveOrder(Order order)
        {
            _dbContext.AttachRange(order.Items.Select(p => p.Product));

            if (order.OrderID == 0)
                _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();
        }
    }
}