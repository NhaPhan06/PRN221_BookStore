﻿using DataAccess.DataAccess;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository {
    public interface IOrderDetailRepository : IGeneric<OrderDetail> {
        public  OrderDetail GetOrderDetailById(Guid id);

        
    }
}