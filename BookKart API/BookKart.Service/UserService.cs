using BookKart.Core.Application.BaseService;
using BookKart.Core.Application.Utils;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;

namespace BookKart.Service
{
    public class UserService : BaseService<User, long>
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ReturnResult IsUserAuthenticated(User userObj)
        {
            ReturnResult result = new ReturnResult();

            var user = _repository
                   .GetAll()
                   .FirstOrDefault(x => x.EmailId.ToLower() == userObj.EmailId.ToLower());
            if (user != null)
            {
                if (userObj.Password == user.Password)
                {
                    result.Data = user;
                    result.Message = "Authenticated User";
                    result.ResponseCode = ResponseStatus.Success.ToString();
                }
            }
            else
            {
                result.Message = "Not Authenticated";
                result.ResponseCode = ResponseStatus.Error.ToString();
            }
            return result;
        }
    }
}
