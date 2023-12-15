using DataAccess.Model;
using ModelLayer.Model;

namespace BusinessLayer.Service;

public interface IOrderService
{
    Task CreateOrder(List<Carts> cart, Order order);
    List<Order> GetAll();
    List<Order> Search();
    Order DisableOrder(Guid id);
    Order GetOrderById(Guid id);
    Order ReciveOrder(Guid id);
    Order DeliveryOrder(Guid id);
    Order ConfirmOrder(Guid id);
    List<Order> GetOrdersByUserId(Guid id);
    IList<Order> Get10Orders();
}