using BookKart.Core.Application.BaseService;
using BookKart.Core.Application.Utils;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;

namespace BookKart.Service
{
    public class CartService : BaseService<Cart, long>
    {
        private readonly ICartRepository _repository;
        public CartService(ICartRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ReturnResult GetCartForUser(long userId)
        {
            var result = new ReturnResult();
            try
            {
                var cartObj = _repository.GetAll().Where(x => x.UserId == userId).ToList();
                if (cartObj.Count > 0)
                {
                    result.ResponseCode = ResponseStatus.Success.ToString();
                    result.Data = cartObj;
                }
                else
                {
                    result.ResponseCode = ResponseStatus.Error.ToString();
                    result.Message = "Cart is empty";
                }

            }
            catch (Exception ex)
            {
                result.ResponseCode = ResponseStatus.Error.ToString();
                result.Message = $"Error in featching cart.{ex.Message}";
            }
            return result;
        }

        public async Task<ReturnResult> EmptyCart(long userId)
        {
            var result = new ReturnResult();
            try
            {
                var cartObj = _repository.GetAll().Where(x => x.UserId == userId).ToList();
                if (cartObj.Count > 0)
                {
                    await _repository.RemoveRangeAsync(cartObj);
                    result.ResponseCode = ResponseStatus.Success.ToString();
                    result.Message = "Cart Empty";
                }
            }
            catch (Exception ex)
            {
                result.ResponseCode = ResponseStatus.Error.ToString();
                result.Message = $"Error in deleting cart.{ex.Message}";
            }
            return result;
        }
    }
}
