using BookKart.Core.Application.BaseService;
using BookKart.Core.Application.EntityBase;
using BookKart.Core.Application.Exceptions;
using BookKart.Core.Application.Utils;
using BookKart.Core.Infrastructure.EFException;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers
{
    public abstract class WebApiControllerBase<TEntity, TId> : ControllerBase
   where TEntity : BaseEntity<TId>, new()
    {
        protected BaseService<TEntity, TId> _baseService;

        protected WebApiControllerBase(BaseService<TEntity, TId> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual IEnumerable<TEntity> Get()
        {
            return _baseService.GetAll();
        }

        [HttpGet("{key}")]
        public virtual async Task<TEntity> Get(TId key)
        {
            return await _baseService.GetById(key);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity domain)
        {
            try
            {
                await _baseService.AddAsync(domain);
                return CreatedAtAction(nameof(Get), new { key = domain.Id },
                  new ReturnResult
                  {
                      ResponseCode = ResponseStatus.Success.ToString(),
                      Data = domain
                  });
            }
            catch (Exception ex)
            {
                var duplicateExp = ex as DuplicateKeyException<TEntity>;
                if (duplicateExp != null)
                    return Ok(new ReturnResult
                    {
                        ResponseCode = ResponseStatus.Error.ToString(),
                        Message = duplicateExp.Message
                    });

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TEntity domain)
        {
            try
            {
                await _baseService.UpdateAsync(domain);
                return Ok(new ReturnResult
                {
                    ResponseCode = ResponseStatus.Success.ToString(),
                });
            }
            catch (Exception ex)
            {
                var duplicateExp = ex as DuplicateKeyException<TEntity>;
                if (duplicateExp != null)
                    return Ok(new ReturnResult
                    {
                        ResponseCode = ResponseStatus.Error.ToString(),
                        Message = duplicateExp.Message
                    });

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TId id)
        {
            try
            {
                await _baseService.RemoveAsync(id);
                return NoContent();
            }
            catch (CoreException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBulkData")]
        public virtual async Task<IActionResult> AddBulkData(IEnumerable<TEntity> entities)
        {
            try
            {
                await _baseService.BulkAddAsync(entities);
                return Ok(new ReturnResult
                {
                    ResponseCode = ResponseStatus.Success.ToString(),
                });
            }
            catch (Exception ex)
            {
                return Ok(new ReturnResult
                {
                    ResponseCode = ResponseStatus.Error.ToString(),
                    Message = ex.Message
                });
            }
        }


    }
}
