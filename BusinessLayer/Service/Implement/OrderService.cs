using DataAccess.DataAccess;
using DataAccess.Enum;
using DataAccess.Repository;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessLayer.Service.Implement {
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Order> GetAll() => _unitOfWork.OrderRepository.GetAllOrder();        

        public List<Order> Search()
        {
            throw new NotImplementedException();
        }

        public Order DisableOrder(Guid id)
        {
            var orders = _unitOfWork.OrderRepository.GetOrderById(id);
            orders.Status = OrderStatus.Disable.ToString();
            var Update = _unitOfWork.OrderRepository.UpdateOrder(orders);
            _unitOfWork.OrderRepository.SaveChange();  
            return Update;
        }
        public Order ReciveOrder(Guid id)
        {
            var orders = _unitOfWork.OrderRepository.GetOrderById(id);
            orders.Status = OrderStatus.Recive.ToString();
            var Update = _unitOfWork.OrderRepository.UpdateOrder(orders);
            _unitOfWork.OrderRepository.SaveChange();
            return Update;
        }
        public Order DeliveryOrder(Guid id)
        {
            var orders = _unitOfWork.OrderRepository.GetOrderById(id);
            orders.Status = OrderStatus.Delivery.ToString();
            var Update = _unitOfWork.OrderRepository.UpdateOrder(orders);
            _unitOfWork.OrderRepository.SaveChange();
            return Update;
        }
        public Order ConfirmOrder(Guid id)
        {
            var orders = _unitOfWork.OrderRepository.GetOrderById(id);
            orders.Status = OrderStatus.Confirm.ToString();
            var Update = _unitOfWork.OrderRepository.UpdateOrder(orders);
            _unitOfWork.OrderRepository.SaveChange();
            return Update;
        }

        public Order GetOrderById(Guid id)
        {
           return _unitOfWork.OrderRepository.GetOrderById(id);
        }

        public List<Order> GetOrdersByUserId(Guid id)
        {
            return _unitOfWork.OrderRepository.GetOrdersByUserId(id);
        }
    }
}