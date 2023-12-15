using DataAccess.DataAccess;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessLayer.Service.Implement
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(Guid orderId)
        {
            return _unitOfWork.OrderDetailRepository.GetOrderDetailByOrderId(orderId);
        }

        public List<OrderDetail> GetAllOrderDetailByOrderId(Guid id)
        {
            return _unitOfWork.OrderDetailRepository.GetAllOrderDetailByOrderId(id);
        }

        public OrderDetail GetOrderDetailById(Guid id)
        {
            return _unitOfWork.OrderDetailRepository.GetById(id);
        }
    }
}