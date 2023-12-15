using DataAccess.Infrastructure;
using ModelLayer.Model;

namespace DataAccess.Repository;

public interface IOrderDetailRepository : IGeneric<OrderDetail>
{
    List<OrderDetail> GetOrderDetailByOrderId(Guid id);
    public OrderDetail GetOrderDetailById(Guid id);
    List<OrderDetail> GetAllOrderDetailByOrderId(Guid id);
}