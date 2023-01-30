using Hali.Core.Models;
using Hali.Core.Repositories;

namespace Hali.Repository.Repositories
{
    public class ProcessOrderRepository : GenericRepository<ProcessOrder>, IProcessOrderRepository
    {
        public ProcessOrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
