using BookKart.Core.Domain.Entities;
using BookKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : WebApiControllerBase<Category, long>
{
    public CategoryController(CategoryService categoryService) : base(categoryService)
    {

    }
}
