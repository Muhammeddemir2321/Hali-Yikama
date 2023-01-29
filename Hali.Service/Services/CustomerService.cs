using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Repository.Repositories;
using Hali.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Service.Services
{
    public class CustomerService : Service<Customer, CustomerDto>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IGenericRepository<Customer> repository, IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository) : base(repository, mapper, unitOfWork)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ResponseDto<CustomerDto>> AddAsync(CustomerCreateDto dto)
        {
            var newEntity = _mapper.Map<Customer>(dto);
            await _customerRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<CustomerDto>(newEntity);
            return ResponseDto<CustomerDto>.Succes(newDto, 201);
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(CustomerUpdateDto dto)
        {
            var newEntity=_mapper.Map<Customer>(dto);
            _customerRepository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(204);
        }
    }
}
