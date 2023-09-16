using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Pagination;

namespace LawFirm.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<PagedList<T>> GetPagedItems(ItemsParameters itemsParameters);
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
}