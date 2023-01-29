using Hali.Core.DTOs;
using Hali.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : CustomBaseController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _companyService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyDto companyDto)
        {
            return CreateActionResult(await _companyService.AddAsync(companyDto));
        }
        
    }
}
