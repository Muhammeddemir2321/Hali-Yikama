using Hali.Core.DTOs;
using Hali.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    public class ProcessOrdersController : CustomBaseController
    { 
        private readonly IProcessOrderService _processOrderService;

        public ProcessOrdersController(IProcessOrderService processOrderService)
        {
            _processOrderService = processOrderService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(ProcessOrderCreateDto dto)
        {
            return CreateActionResult(await _processOrderService.AddAsync(dto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRange(List<ProcessOrderCreateDto> dtos)
        {
            return CreateActionResult(await _processOrderService.AddRangeAsync(dtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProcessOrderUpdateDto dto)
        {
            return CreateActionResult(await _processOrderService.UpdateAsync(dto));
        }
    }
}
