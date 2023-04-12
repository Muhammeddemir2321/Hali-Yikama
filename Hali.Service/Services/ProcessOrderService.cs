using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Hali.Service.Services
{
    public class ProcessOrderService : Service<ProcessOrder, ProcessOrderDto>, IProcessOrderService 
    {
        private readonly IProcessOrderRepository _processOrderRepository;
        private readonly IOrderRepository _orderRepository;
        public ProcessOrderService(IGenericRepository<ProcessOrder> repository, IMapper mapper, IUnitOfWork unitOfWork, IProcessOrderRepository processOrderRepository, IOrderRepository orderRepository) : base(repository, mapper, unitOfWork)
        {
            _processOrderRepository = processOrderRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ResponseDto<ProcessOrderDto>> AddAsync(ProcessOrderCreateDto processOrderCreateDto)
        {
            var newEntity = _mapper.Map<ProcessOrder>(processOrderCreateDto);
            await _processOrderRepository.AddAsync(newEntity);
            var orderEntity = await _orderRepository.Where(x => x.Id == newEntity.OrderId).SingleOrDefaultAsync();
            orderEntity.TotalPrice += newEntity.Price;
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<ProcessOrderDto>(newEntity);
            return ResponseDto<ProcessOrderDto>.Succes(newDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<IEnumerable<ProcessOrderDto>>> AddRangeAsync(List<ProcessOrderCreateDto> processOrderCreateDtos)
        {
            var newEntities = _mapper.Map<List<ProcessOrder>>(processOrderCreateDtos);
            await _processOrderRepository.AddRangeAsync(newEntities);

            var orderEntity = await _orderRepository.Where(x => x.Id == newEntities.FirstOrDefault().OrderId).SingleOrDefaultAsync();

            foreach (var item in newEntities)
            {
                orderEntity.TotalPrice += item.Price;
            }
            await _unitOfWork.CommitAsync();
            var newDtos = _mapper.Map<List<ProcessOrderDto>>(newEntities);
            return ResponseDto<IEnumerable<ProcessOrderDto>>.Succes(newDtos, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(ProcessOrderUpdateDto processOrderUpdateDto)
        {
            var newEntity = _mapper.Map<ProcessOrder>(processOrderUpdateDto);
            _processOrderRepository.Update(newEntity);

            var orderEntity = await _orderRepository.Where(x => x.Id == newEntity.OrderId).SingleOrDefaultAsync();

            var AllProcessOrders = await _processOrderRepository.GetAll().ToListAsync();

            orderEntity.TotalPrice = 0;

            foreach (var item in AllProcessOrders)
            {
                orderEntity.TotalPrice += item.Price;
            }
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(StatusCodes.Status204NoContent);
        }
    }
}
