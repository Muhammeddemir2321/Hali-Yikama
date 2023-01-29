using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Repository.UnitOfWorks;
using Hali.Shared.DTOs;

namespace Hali.Service.Services
{
    public class ProcessService : Service<Process, ProcessDto>, IProcessService
    {
        private readonly IProcessRepository _processRepository;
        public ProcessService(IGenericRepository<Process> repository, IMapper mapper, IUnitOfWork unitOfWork, IProcessRepository processRepository) : base(repository, mapper, unitOfWork)
        {
            _processRepository = processRepository;
        }

        public async Task<ResponseDto<ProcessDto>> AddAsync(ProcessCreateDto dto)
        {
            var newEntity = _mapper.Map<Process>(dto);
            await _processRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<ProcessDto>(newEntity);
            return ResponseDto<ProcessDto>.Succes(newDto, 201);
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(ProcessUpdateDto dto)
        {
            var newEntity = _mapper.Map<Process>(dto);
            _processRepository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(204);
        }
    }
}
