using BookKart.Core.Application.Utils;
using BookKart.Core.Domain.Entities;
using BookKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : WebApiControllerBase<User, long>
{
    private readonly UserService _userService;
    public UserController(UserService userService) : base(userService)
    {
        _userService = userService;
    }

    [HttpPost("AuthenticateUser")]
    public IActionResult AuthenticateUser([FromBody] User user)
    {
        var returnResult = _userService.IsUserAuthenticated(user);
        return Ok(new ReturnResult
        {
            ResponseCode = returnResult.ResponseCode,
            Data = returnResult.Data,
            Message = returnResult.Message
        });
    }

    //[HttpPost("ResetPassword")]
    //public async Task<IActionResult> ResetPassword(string email)
    //{
    //    var returnResult = await _userService.ResetPassword(email);
    //    return Ok(new ReturnResult
    //    {
    //        ResponseCode = returnResult.ResponseCode,
    //        Data = returnResult.Data,
    //        Message = returnResult.Message
    //    });
    //}
}
