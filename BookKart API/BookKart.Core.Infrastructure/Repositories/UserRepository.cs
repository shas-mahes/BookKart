using BookKart.Core.Application.Interface;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;
using BookKart.Core.Infrastructure.DataContext;
using BookKart.Core.Infrastructure.Repositories.RepositoryBase;

namespace BookKart.Core.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext, IUnitOfWork unitOfWork) :
         base(dbContext, unitOfWork)
        {
        }
    }
}
