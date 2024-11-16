using BookKart.Core.Application.BaseService;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;

namespace BookKart.Service
{
    public class CategoryService : BaseService<Category, long>
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {

        }
    }
}
