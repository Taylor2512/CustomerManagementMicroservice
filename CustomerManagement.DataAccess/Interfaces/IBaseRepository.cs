using AutoMapper;

using CustomerManagement.DataAccess.Models;

namespace CustomerManagement.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        IQueryable<T> All { get; }

        T? FindAll(params object[] keyValues);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllPaginate(int page = 1, int take = 5);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IQueryable<TDo>> GetAllAsync<TDo>(IMapper mapper);
        Task<TDto?> FindAllAsync<TDto>(IMapper mapper, params object[] keyValues);
        Task<IQueryable<TDo>> GetAllPaginateAsync<TDo>(IMapper mapper, int page = 1, int take = 5);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        void SaveChange();
        Task SaveChangesAsync();
    }
}