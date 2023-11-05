using System.Linq.Expressions;

namespace LawFirm.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<IReadOnlyList<T>> ListAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
}