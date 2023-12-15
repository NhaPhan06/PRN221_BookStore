using ModelLayer.Model;

namespace BusinessLayer.Service;

public interface IOrderDetailService
{
    OrderDetail GetOrderDetailById(Guid id);
    List<OrderDetail> GetAllOrderDetailByOrderId(Guid id);
    List<OrderDetail> GetOrderDetailByOrderId(Guid orderId);
}