using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Shared.DTOs;

namespace Hali.Core.Services
{
    public interface IOrderService : IService<Order, OrderDto>
    {
        public Task<ResponseDto<OrderWithProcessOrderDto>> CreateOrderWithProcessOrderAsync(OrderWithProcessOrderCreateDto orderWithProcessOrderCreateDto);
    }
}
