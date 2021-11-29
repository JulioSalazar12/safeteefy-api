using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Domain.Repositories;
using safeteefy_api.Shared.Persistence.Context;
using safeteefy_api.Shared.Persistence.Repositories;

namespace safeteefy_api.Guardians.Persistence.Repositories
{
    public class GuardianRepository : BaseRepository, IGuardianRepository
    {
        public GuardianRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Guardian>> ListAsync()
        {
            return await _context.Guardians.ToListAsync();
        }

        public async Task AddAsync(Guardian guardian)
        {
            await _context.Guardians.AddAsync(guardian);
        }

        public async Task<Guardian> FindByIdAsync(int id)
        {
            return await _context.Guardians.FindAsync(id);
        }

        public void Update(Guardian guardian)
        {
            _context.Guardians.Update(guardian);
        }

        public void Remove(Guardian guardian)
        {
            _context.Guardians.Remove(guardian);
        }
    }
}