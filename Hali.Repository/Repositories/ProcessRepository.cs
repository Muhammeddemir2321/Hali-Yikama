using Hali.Core.Models;
using Hali.Core.Repositories;

namespace Hali.Repository.Repositories
{
    public class ProcessRepository : GenericRepository<Process>, IProcessRepository
    {
        public ProcessRepository(AppDbContext context) : base(context)
        {
        }
    }
}
