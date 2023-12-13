using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement {
    public class OrderDetailRepository : Generic<OrderDetail>, IOrderDetailRepository {
        public OrderDetailRepository(PRN_BookStoreContext context) : base(context) {
        }
    }
}