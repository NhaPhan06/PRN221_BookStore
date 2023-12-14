using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DataAccess.Repository.Implement {
    public class OrderRepository : Generic<Order>, IOrderRepository {
        public readonly PRN_BookStoreContext _context;
        public OrderRepository(PRN_BookStoreContext context) : base(context) {
            _context = context;
            
        }

        public List<Order> GetAllOrder() => _context.Set<Order>().Include(c => c.User).ToList();

        public Order GetOrderById(Guid id)
        {
            var orders = _context.Set<Order>().FirstOrDefault(c => c.OrderId == id);
            return orders;
        }

        public List<Order> GetOrdersByUserId(Guid id)
        {
            var orders = _context.Set<Order>().Include(c => c.OrderDetails).Include(c => c.User).Where(c => c.UserId==id).ToList();
            return orders;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public List<Order> Search() => _context.Orders.ToList();

        public Order UpdateOrder(Order order)
        {
            _context.Set<Order>().Update(order);
            return order;
        }

        
    }
}