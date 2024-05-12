using AutoMapper;
using AutoMapper.QueryableExtensions;

using CustomerManagement.DataAccess.Context;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;

 
namespace CustomerManagement.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly CustomerDbContext _context;
        public BaseRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> All => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return All;
        }
        public T? FindAll(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public IQueryable<T> GetAllPaginate(int page = 1, int take = 5)
        {
            return _context.Set<T>().Skip((page - 1) * take).Take(take);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                 baseEntity.Activo = true;
                 baseEntity.UsuarioCreacion = baseEntity.UsuarioCreacion ?? "SIN USUARIO";
            }
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
             if (entity is IEntity baseEntity)
            {
                 baseEntity.Activo = false;
                 this.Update(entity);
             }
        }


        public   Task<IQueryable<TDo>> GetAllAsync<TDo>(IMapper mapper)
        {
            var entities = _context.Set<T>().ProjectTo<TDo>(mapper.ConfigurationProvider);
             return  Task.FromResult( entities);
        }

        public async Task<TDto?> FindAllAsync<TDto>(IMapper mapper, params object[] keyValues)
        {
            var entity = await _context.Set<T>().FindAsync(keyValues);
            if (entity == null)
            {
                return default;
            }
            else
            {
                var entityDto = mapper.Map<TDto>(entity);
                return entityDto;
            }
        }

        public async Task<IQueryable<TDo>> GetAllPaginateAsync<TDo>(IMapper mapper, int page = 1, int take = 5)
        {
            var entities = _context.Set<T>()
                .Skip((page - 1) * take)
                .Take(take)
                .ProjectTo<TDo>(mapper.ConfigurationProvider);

            return await Task.FromResult(entities);
        }

        public async Task AddAsync(T entity)
        {
            
            this.Add(entity);
              await Task.CompletedTask;

        }

        public async Task UpdateAsync(T entity)
        {
            this.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is IEntity baseEntity)
            {
                baseEntity.Activo = false;
              await  this.UpdateAsync(entity);
            }

             await Task.CompletedTask;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
