using BookKart.Core.Application.Interface;
using BookKart.Core.Application.Exceptions;
using BookKart.Core.Application.Utils.Extensions;

namespace BookKart.Core.Application.BaseService;
public abstract class BaseService<TEntity, TId>
    where TEntity : class, new()
{
    private readonly IBaseRepository<TEntity> _repository;

    public BaseService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _repository.GetAll();
    }

    public virtual async Task<TEntity> GetById(TId id)
    {
        if (id.IsNullOrEmpty())
            ThrowExceptionForInvalidLookupIdParameter();

        var entityInDb = await _repository.GetById(id);

        if (entityInDb == null)
            ThrowExceptionForNonExistantEntity(id);

        return entityInDb;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null)
            ThrowExceptionForNullInputEntity();

        return await _repository.AddAsync(entity);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null)
            ThrowExceptionForNullInputEntity();

        return await _repository.UpdateAsync(entity);
    }

    public virtual async Task RemoveAsync(TId id)
    {
        var entityInDb = await GetById(id);

        await _repository.RemoveAsync(entityInDb);
    }

    protected virtual void ThrowExceptionForNullInputEntity()
    {
        throw new NullInputEntityException<TEntity>();
    }

    protected virtual void ThrowExceptionForInvalidLookupIdParameter()
    {
        throw new InvalidLookupIdParameterException<TEntity>();
    }

    protected virtual void ThrowExceptionForNonExistantEntity(TId idValue)
    {
        throw new NonExistantEntityException<TEntity>(idValue);
    }

    public virtual async Task BulkAddAsync(IEnumerable<TEntity> entities)
    {
        await _repository.AddRangeAsync(entities);
    }

    public virtual async Task BulkUpdateAsync(IEnumerable<TEntity> entities)
    {
        await _repository.UpdateRangeAsync(entities);
    }

    public virtual async Task BulkRemoveAsync(IEnumerable<TEntity> entities)
    {
        await _repository.RemoveRangeAsync(entities);
    }
}
