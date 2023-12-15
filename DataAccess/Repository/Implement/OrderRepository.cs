using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Implement
{
    public class OrderRepository : Generic<Order>, IOrderRepository
    {
        public readonly PRN_BookStoreContext _context;

        public OrderRepository(PRN_BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetAllOrder()
        {
            return _context.Set<Order>().Include(c => c.User).ToList();
        }

        public Order GetOrderById(Guid id)
        {
            Order? orders = _context.Set<Order>().FirstOrDefault(c => c.OrderId == id);
            return orders;
        }

        public List<Order> GetOrdersByUserId(Guid id)
        {
            List<Order> orders = _context.Set<Order>().Include(c => c.OrderDetails).Include(c => c.User)
                .Where(c => c.UserId == id).ToList();
            return orders;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public List<Order> Search()
        {
            return _context.Orders.ToList();
        }

        public Order UpdateOrder(Order order)
        {
            _context.Set<Order>().Update(order);
            return order;
        }
    }
}