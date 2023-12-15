using DataAccess.DataAccess;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository {
    public interface IOrderDetailRepository : IGeneric<OrderDetail> {
        List<OrderDetail> GetOrderDetailByOrderId(Guid id);
        public OrderDetail GetOrderDetailById(Guid id);
        List<OrderDetail> GetAllOrderDetailByOrderId(Guid id);
    }
}