using System.Linq.Expressions;

namespace BookKart.Core.Application.Interface;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    Task RemoveAsync(TEntity entity);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllWithEagerloading(string[] children);
    Task<TEntity> GetById<TId>(TId id);
    IQueryable<TEntity> GetAllAsNoTracking();
    void RemoveTestDataForEntity(TEntity entity);
    void ClearTestDataFromTables(List<string> tableNames);
}
