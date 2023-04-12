using Hali.Core.Models;
using Hali.Core.Repositories;

namespace Hali.Repository.Repositories
{ 
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
