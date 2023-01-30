using Hali.Core.UnitOfWorks;

namespace Hali.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
