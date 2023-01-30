using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Shared.DTOs;

namespace Hali.Core.Services
{
    public interface ICustomerService : IService<Customer, CustomerDto>
    {
        Task<ResponseDto<CustomerDto>> AddAsync(CustomerCreateDto dto);
        Task<ResponseDto<NoContent>> UpdateAsync(CustomerUpdateDto dto);
    }
}
