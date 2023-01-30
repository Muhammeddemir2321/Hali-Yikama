using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Shared.DTOs;

namespace Hali.Core.Services
{
    public interface IProcessOrderService : IService<ProcessOrder, ProcessOrderDto>
    {
        Task<ResponseDto<ProcessOrderDto>> AddAsync(ProcessOrderCreateDto processOrderCreateDto);
        Task<ResponseDto<IEnumerable<ProcessOrderDto>>> AddRangeAsync(List<ProcessOrderCreateDto> processOrderCreateDtos);
        Task<ResponseDto<NoContent>> UpdateAsync(ProcessOrderUpdateDto processOrderUpdateDto);
    }
}
