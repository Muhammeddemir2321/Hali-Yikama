using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Shared.DTOs;
using Microsoft.AspNetCore.Http;

namespace Hali.Service.Services
{
    public class OrderService : Service<Order, OrderDto>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProcessOrderRepository _processOrderRepository;
        public OrderService(IGenericRepository<Order> repository, IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IProcessOrderRepository processOrderRepository) : base(repository, mapper, unitOfWork)
        {
            _orderRepository = orderRepository;
            _processOrderRepository = processOrderRepository;
        }

        public async Task<ResponseDto<OrderWithProcessOrderDto>> CreateOrderWithProcessOrderAsync(OrderWithProcessOrderCreateDto orderWithProcessOrderCreateDto)
        {
            var orderEntity = _mapper.Map<Order>(orderWithProcessOrderCreateDto);
            await _orderRepository.AddAsync(orderEntity);
            await _unitOfWork.CommitAsync();

            var processOrderEntity = _mapper.Map<ProcessOrder>(orderWithProcessOrderCreateDto);
            processOrderEntity.OrderId = orderEntity.Id;
            await _processOrderRepository.AddAsync(processOrderEntity);
            await _unitOfWork.CommitAsync();

            var orderWithProcessOrderDto = _mapper.Map<OrderWithProcessOrderDto>(processOrderEntity);

            return ResponseDto<OrderWithProcessOrderDto>.Succes(orderWithProcessOrderDto, StatusCodes.Status201Created);
        }
    }
}
