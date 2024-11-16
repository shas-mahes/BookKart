using BookKart.Core.Application.BaseService;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;

namespace BookKart.Service
{
    public class UserRoleService : BaseService<UserRole, long>
    {
        public UserRoleService(IUserRoleRepository repository) : base(repository)
        {

        }
    }
}
