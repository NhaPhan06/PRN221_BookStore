﻿using DataAccess.Enum;
using DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;

namespace DataAccess.Repository.Implement;

public class OrderRepository : Generic<Order>, IOrderRepository
{
    public readonly PRN_BookStoreContext _context;

    public OrderRepository(PRN_BookStoreContext context) : base(context)
    {
        _context = context;
    }

    public List<Order> GetAllOrder()
    {
        return _context.Set<Order>().Include(c => c.User).ToList();
    }

    public Order GetOrderById(Guid id)
    {
        var orders = _context.Set<Order>().Include(o => o.User).FirstOrDefault(c => c.OrderId == id);
        return orders;
    }

    public List<Order> GetOrdersByUserId(Guid id)
    {
        var orders = _context.Set<Order>().Include(c => c.OrderDetails).Include(c => c.User)
            .Where(c => c.UserId == id).ToList();
        return orders;
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public List<Order> Search()
    {
        return _context.Orders.ToList();
    }

    public Order UpdateOrder(Order order)
    {
        _context.Set<Order>().Update(order);
        return order;
    }
    
    public List<Order> Get10()
    {
        var date = DateTime.Now - new TimeSpan(0, 24, 0, 0);
        return _context.Orders.Where(c => c.Status == OrderStatus.PENDING.ToString() && c.OrderDate <= date).OrderByDescending(o => o.OrderDate).Take(10).ToList();
    }
}