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

    public virtual async Task<T?> GetByIdAsync(Guid id, bool asNoTracking = false, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        T? entity = await query.SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        return entity;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(bool asNoTracking = false, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (asNoTracking)
        {
            query = query.AsNoTracking();
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

    public async Task UpdateAsync(T entity, params Expression<Func<T, object>>[] navigations)
    {
        var dbEntity = _dbContext.Set<T>().Attach(entity);

        dbEntity.State = EntityState.Modified;

        foreach (var navigation in navigations)
        {
            var accessor = navigation.Compile();
            var relatedEntity = accessor(entity);

            if (relatedEntity is IEnumerable<object> relatedEntities)
            {
                foreach (var related in relatedEntities)
                {
                    UpdateRelatedEntity(related);
                }
            }
            else
            {
                UpdateRelatedEntity(relatedEntity);
            }
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    private void UpdateRelatedEntity(object relatedEntity)
    {
        if (_dbContext.Entry(relatedEntity).State == EntityState.Detached)
        {
            _dbContext.Attach(relatedEntity);
        }

        if (_dbContext.Entry(relatedEntity).State == EntityState.Modified)
        {
            _dbContext.Entry(relatedEntity).State = EntityState.Modified;
        }
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
}