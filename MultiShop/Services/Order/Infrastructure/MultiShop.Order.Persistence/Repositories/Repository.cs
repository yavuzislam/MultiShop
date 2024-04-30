using MultiShop.Order.Application.Interfaces;
using System.Linq.Expressions;

namespace MultiShop.Order.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ordercont
    public Task<T> CreateAsync(T entity)
    {
    }

    public Task<T> DeleteAsync(T entity)
    {
    }

    public Task<List<T>> GetAllAsync()
    {
    }

    public Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
    }

    public Task<T> GetByIdAsync(int id)
    {
    }

    public Task<T> UpdateAsync(T entity)
    {
    }
}
