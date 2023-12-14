using DataAccess.DataAccess;

namespace BusinessLayer.Service {
    public interface IOrderDetailService {
        List<OrderDetail> GetOrderDetailByOrderId(Guid orderId);
    }
}