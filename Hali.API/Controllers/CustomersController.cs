using Hali.API.Filters;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _customerService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _customerService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerCreateDto customerCreateDto)
        {
            return CreateActionResult(await _customerService.AddAsync(customerCreateDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            return CreateActionResult(await _customerService.UpdateAsync(customerUpdateDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _customerService.RemoveAsync(id));
        }
    }
}
