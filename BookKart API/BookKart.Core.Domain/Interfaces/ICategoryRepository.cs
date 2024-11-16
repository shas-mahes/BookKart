using BookKart.Core.Application.Interface;
using BookKart.Core.Domain.Entities;

namespace BookKart.Core.Domain.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
