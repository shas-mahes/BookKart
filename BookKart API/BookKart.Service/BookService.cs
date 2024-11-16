using BookKart.Core.Application.BaseService;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;

namespace BookKart.Service
{ 
    public class BookService : BaseService<Book, long>
    {
        public BookService(IBookRepository repository) : base(repository)
        {

        }
    }
}
