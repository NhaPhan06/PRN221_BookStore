using DataAccess.DataAccess;

namespace BusinessLayer.Service {
    public interface IOrderDetailService {
        
        OrderDetail GetOrderDetailById(Guid id);
    }
}