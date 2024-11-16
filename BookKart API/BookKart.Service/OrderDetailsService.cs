using BookKart.Core.Application.BaseService;
using BookKart.Core.Domain.Entities;
using BookKart.Core.Domain.Interfaces;

namespace BookKart.Service
{
    public class OrderDetailsService : BaseService<OrderDetails, long>
    {
        public OrderDetailsService(IOrderDetailsRepository repository) : base(repository)
        {

        }
    }
}
