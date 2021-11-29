using System.Threading.Tasks;
using safeteefy_api.Shared.Domain.Repositories;
using safeteefy_api.Shared.Persistence.Context;

namespace safeteefy_api.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}