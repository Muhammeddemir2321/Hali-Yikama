using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;

namespace Hali.Service.Services
{
    public class CompanyService : Service<Company, CompanyDto>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(IGenericRepository<Company> repository, IMapper mapper, IUnitOfWork unitOfWork,ICompanyRepository companyRepository) : base(repository, mapper, unitOfWork)
        {
            _companyRepository=companyRepository;
        }
    }


}