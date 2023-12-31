﻿using DataAccess.Repository;
using DataAccess.Repository.Implement;

namespace DataAccess.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public readonly PRN_BookStoreContext _context;

    public UnitOfWork(PRN_BookStoreContext context)
    {
        // ReSharper disable once RedundantAssignment
        _context = context;
        BookRepository = new BookRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        UserRepository = new UserRepository(_context);
        OrderRepository = new OrderRepository(_context);
        OrderDetailRepository = new OrderDetailRepository(_context);
    }

    public IBookRepository BookRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IUserRepository UserRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderDetailRepository OrderDetailRepository { get; }

    public void Save()
    {
        _context.SaveChanges();
    }
}