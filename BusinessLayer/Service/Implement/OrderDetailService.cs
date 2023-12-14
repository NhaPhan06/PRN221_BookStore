using DataAccess.DataAccess;
using DataAccess.Repository.Generic.UnitOfWork;

namespace BusinessLayer.Service.Implement {
    public class OrderDetailService : IOrderDetailService
        
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public OrderDetail GetOrderDetailById(Guid id) => _unitOfWork.OrderDetailRepository.GetById(id);
        
    }
}