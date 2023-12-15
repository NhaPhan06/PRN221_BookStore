using DataAccess.Infrastructure;
using ModelLayer.Model;

namespace DataAccess.Repository;

public interface IOrderRepository : IGeneric<Order>
{
    public List<Order> Get10();
    public List<Order> GetAllOrder();
    public List<Order> Search();

    public Order UpdateOrder(Order order);

    public Order GetOrderById(Guid id);
    void SaveChange();
    List<Order> GetOrdersByUserId(Guid id);
}