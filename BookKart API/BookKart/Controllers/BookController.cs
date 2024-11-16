using BookKart.Core.Domain.Entities;
using BookKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : WebApiControllerBase<Book, long>
{
    public BookController(BookService bookService) : base(bookService)
    {

    }
}
