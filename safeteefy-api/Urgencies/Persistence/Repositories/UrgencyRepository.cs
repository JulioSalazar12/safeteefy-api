using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using safeteefy_api.Shared.Persistence.Context;
using safeteefy_api.Shared.Persistence.Repositories;
using safeteefy_api.Urgencies.Domain.Models;
using safeteefy_api.Urgencies.Domain.Repositories;

namespace safeteefy_api.Urgencies.Persistence.Repositories
{
    public class UrgencyRepository : BaseRepository, IUrgencyRepository
    {
        public UrgencyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Urgency>> ListAsync()
        {
            return await _context.Urgencies
                .Include(p => p.Guardian)
                .ToListAsync();
        }

        public async Task<IEnumerable<Urgency>> FindByGuardianId(int id)
        {
            return await _context.Urgencies
                .Where(p => p.GuardianId == id)
                .Include(p => p.Guardian)
                .ToListAsync();
        }

        public async Task AddAsync(Urgency urgency)
        {
            await _context.Urgencies
                .AddAsync(urgency);
        }

        public async Task<Urgency> FindByIdAsync(int id)
        {
            return await _context.Urgencies
                .Include(p => p.Guardian)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Urgency urgency)
        {
            _context.Urgencies.Update(urgency);
        }

        public void Remove(Urgency urgency)
        {
            _context.Urgencies.Remove(urgency);
        }
    }
}