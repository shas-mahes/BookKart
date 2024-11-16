using BookKart.Core.Domain.Entities;
using BookKart.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookKart.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : WebApiControllerBase<OrderDetails, long>
{
    public OrderDetailsController(OrderDetailsService orderDetailsService) : base(orderDetailsService)
    {

    }
}
