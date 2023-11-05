using LawFirm.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LawFirm.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly LawFirmContext _dbContext;

    public BaseRepository(LawFirmContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        T? entity = await query.SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        return entity;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
    {
        return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}