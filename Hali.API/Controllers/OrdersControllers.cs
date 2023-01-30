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
        public async Task<IActionResult> CreateOrderWithProcessOrder(OrderWithProcessOrdersCreateDto dto)
        {
            return CreateActionResult(await _orderService.CreateOrderWithProcessOrderAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateDto dto)
        {
            return CreateActionResult(await _orderService.UpdateAsync(dto));
        }
    }
}
