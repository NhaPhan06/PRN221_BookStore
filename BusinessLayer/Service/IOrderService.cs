using DataAccess.DataAccess;

namespace BusinessLayer.Service {
    public interface IOrderService {
        List<Order> GetAll();
        List<Order> Search();
        Order DisableOrder(Guid id);
        Order GetOrderById(Guid id);
        Order ReciveOrder(Guid id);
        Order PendingOrder(Guid id);
        Order ConfirmOrder(Guid id);

    }
}