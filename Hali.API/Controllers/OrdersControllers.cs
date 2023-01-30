using Hali.Core.DTOs;
using Hali.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    public class OrdersControllers : CustomBaseController
    {
        private readonly IOrderService _orderService;

        public OrdersControllers(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderWithProcessOrder(OrderWithProcessOrderCreateDto dto)
        {
            return CreateActionResult(await _orderService.CreateOrderWithProcessOrderAsync(dto));
        }
    }
}
