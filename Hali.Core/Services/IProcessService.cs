using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Shared.DTOs;

namespace Hali.Core.Services
{
    public interface IProcessService : IService<Process, ProcessDto>
    {
        public Task<ResponseDto<ProcessDto>> AddAsync(ProcessCreateDto dto);
        public Task<ResponseDto<NoContent>> UpdateAsync(ProcessUpdateDto dto);
    }
}
