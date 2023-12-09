using DataAccess.DataAccess;
using DataAccess.Repository.Implement.Generic;

namespace DataAccess.Repository.Implement;

public class OrderRepository: Generic<Order>, IOrderRepository
{
    public OrderRepository(PRN_BookStoreContext context) : base(context)
    {
    }
}