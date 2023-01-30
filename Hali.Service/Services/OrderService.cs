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

        public async Task<ResponseDto<OrderWithProcessOrdersDto>> CreateOrderWithProcessOrderAsync(OrderWithProcessOrdersCreateDto orderWithProcessOrdersCreateDto)
        {
            var orderEntity = _mapper.Map<Order>(orderWithProcessOrdersCreateDto);
            await _orderRepository.AddAsync(orderEntity);
            await _unitOfWork.CommitAsync();

            //var processOrderEntities = _mapper.Map<List<ProcessOrder>>(orderWithProcessOrdersCreateDto.ProcessOrders);
            //foreach (var item in processOrderEntities)
            //{
            //    item.OrderId = orderEntity.Id;
            //}
            //await _processOrderRepository.AddRangeAsync(processOrderEntities);
            //await _unitOfWork.CommitAsync();

            var orderWithProcessOrdersDto = _mapper.Map<OrderWithProcessOrdersDto>(orderEntity);

            return ResponseDto<OrderWithProcessOrdersDto>.Succes(orderWithProcessOrdersDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var newEntity = _mapper.Map<Order>(orderUpdateDto);
            _orderRepository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(StatusCodes.Status204NoContent);
        }
    }
}
