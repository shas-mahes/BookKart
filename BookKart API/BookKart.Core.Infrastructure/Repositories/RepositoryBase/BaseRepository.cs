using BookKart.Core.Application.Interface;
using BookKart.Core.Infrastructure.EFException;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookKart.Core.Infrastructure.Repositories.RepositoryBase;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;
    protected readonly IUnitOfWork _unitOfWork;

    public BaseRepository(DbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var obj = _dbContext.Add(entity);
        try
        {
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            HandleDbException(ex);
        }

        return obj.Entity;
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            _dbContext.AddRange(entities);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            HandleDbException(ex);
        }
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            _dbContext.UpdateRange(entities);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            HandleDbException(ex);
        }
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>()
          .Where(expression)
          .AsQueryable();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>()
          .AsQueryable();
    }

    public IQueryable<TEntity> GetAllWithEagerloading(string[] children)
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();
        foreach (string entity in children)
        {
            query = query.Include(entity);
        }

        return query;
    }

    public IQueryable<TEntity> GetAllAsNoTracking()
    {
        return _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();
    }

    public async Task<TEntity> GetById<TId>(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbContext.RemoveRange(entities);
        await _unitOfWork.CommitAsync();
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var obj = _dbContext.Update(entity);
        try
        {
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            HandleDbException(ex);
        }

        return obj.Entity;
    }

    public void RemoveTestDataForEntity(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        _unitOfWork.Commit();
    }

    public void ClearTestDataFromTables(List<string> entityNames)
    {
        foreach (var entityName in entityNames)
        {
            var tableName = GetTableNameForEntity(entityName);
            var sql = @"DELETE FROM " + tableName + " WHERE CreatedBy = {0}";
            var parameter = "QMS_Test";
            _dbContext.Database.ExecuteSqlRaw(sql, parameter);
        }
    }

    private string GetTableNameForEntity(string entityName)
    {
        var entityType = _dbContext.Model.FindEntityType(entityName);
        //entityType.GetSchema();
        return entityType.GetTableName();
    }

    protected virtual void HandleDbException(Exception exception)
    {
        if (exception is DbUpdateException dbUpdateEx)
        {
            if (dbUpdateEx.InnerException != null)
            {
                if (dbUpdateEx.InnerException is SqlException sqlException)
                {
                    switch (sqlException.Number)
                    {
                        case 2627:  // Unique constraint error
                        case 547:   // Constraint check violation
                        case 2601:  // Duplicated key row error
                                    // Constraint violation exception
                                    // A custom exception of yours for concurrency issues
                            throw new DuplicateKeyException<TEntity>();
                        default:
                            throw new DbUpdateException(
                              dbUpdateEx.Message, dbUpdateEx.InnerException);
                    }
                }
            }
            throw new DbUpdateException(dbUpdateEx.Message, dbUpdateEx.InnerException);
        }

        throw new Exception(exception.Message, exception.InnerException);
    }
}

