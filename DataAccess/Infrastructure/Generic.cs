using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Infrastructure;

public class Generic<T> : IGeneric<T> where T : class
{
    public readonly PRN_BookStoreContext _context;
    private readonly DbSet<T> _dbSet;

    public Generic(PRN_BookStoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public T SingleOrDefault(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.SingleOrDefault(predicate);
    }

    public T Add(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}