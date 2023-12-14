using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess.Repository.Implement
{
    public class OrderDetailRepository : Generic<OrderDetail>, IOrderDetailRepository
    {
        public readonly PRN_BookStoreContext _context;
        public OrderDetailRepository(PRN_BookStoreContext context) : base(context)
        {
            _context = context;
        }
        public OrderDetail GetOrderDetailById(Guid id)
        {
            var orderdetail = _context.Set<OrderDetail>().FirstOrDefault(c => c.OrderDetailId == id);
            return orderdetail;
        }
        public List<OrderDetail> GetAllOrderDetailByOrderId(Guid id)
        {
            var orderdetails = _context.Set<OrderDetail>()
                .Include(c => c.Book)
                .Where(s => s.OrderId == id).ToList();
            return orderdetails;
        }
    }
}