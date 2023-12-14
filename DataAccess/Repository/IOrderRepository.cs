using DataAccess.DataAccess;
using DataAccess.Repository.Generic;
using System.Data;

namespace DataAccess.Repository {
    public interface IOrderRepository : IGeneric<Order> {
        public List<Order> GetAllOrder();
        public List<Order> Search();

        public Order UpdateOrder(Order order);

        public Order GetOrderById(Guid id);
        void SaveChange();
    }
}