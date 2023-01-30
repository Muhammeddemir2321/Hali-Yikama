using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;

namespace Hali.Service.Services
{
    public class ProcessOrderService : Service<ProcessOrder, ProcessOrderDto>, IProcessOrderService
    {
        public ProcessOrderService(IGenericRepository<ProcessOrder> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }
    }
}
