using Hali.Core.DTOs;
using Hali.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : CustomBaseController
    {
        private readonly IProcessService _service;

        public ProcessesController(IProcessService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(ProcessCreateDto processCreateDto)
        {
            return CreateActionResult(await _service.AddAsync(processCreateDto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange(ICollection<ProcessDto> processDtos)
        {
            return CreateActionResult(await _service.AddRangeAsync(processDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProcessUpdateDto processUpdateDto)
        {
            return CreateActionResult(await _service.UpdateAsync(processUpdateDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRange(ICollection<int> ids)
        {
            return CreateActionResult(await _service.RemoveRangeAsync(ids));
        }
    }
}
