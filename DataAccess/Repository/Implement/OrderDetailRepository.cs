using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Implement {
    public class OrderDetailRepository : Generic<OrderDetail>, IOrderDetailRepository {
        private readonly PRN_BookStoreContext _context;
        public OrderDetailRepository(PRN_BookStoreContext context) : base(context) {
            _context = context;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(Guid id)
        {
            return _context.Set<OrderDetail>().Include(c => c.Book).Include(c => c.Order).Where(c => c.OrderId == id).ToList();
        }
    }
}