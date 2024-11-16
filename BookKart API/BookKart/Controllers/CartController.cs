using BookKart.Core.Application.Utils;
using BookKart.Core.Domain.Entities;
using BookKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : WebApiControllerBase<Cart, long>
{
    private readonly CartService _cartService;
    public CartController(CartService cartService) : base(cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("GetCartForUser/{userId}")]
    public async Task<ReturnResult> GetCart(long userId)
    {
        return _cartService.GetCartForUser(userId);
    }

    [HttpGet("EmptyCart/{userId}")]
    public async Task<ReturnResult> EmptyCart(long userId)
    {
        return await _cartService.EmptyCart(userId);
    }
}
