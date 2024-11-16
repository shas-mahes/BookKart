using BookKart.Core.Domain.Entities;
using BookKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : WebApiControllerBase<UserRole, long>
{
    public UserRoleController(UserRoleService userRoleService) : base(userRoleService)
    {

    }
}
