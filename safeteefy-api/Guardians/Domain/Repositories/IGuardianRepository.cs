using System.Collections.Generic;
using System.Threading.Tasks;
using safeteefy_api.Guardians.Domain.Models;

namespace safeteefy_api.Guardians.Domain.Repositories
{
    public interface IGuardianRepository
    {
        Task<IEnumerable<Guardian>> ListAsync();
        Task AddAsync(Guardian guardian);
        Task<Guardian> FindByIdAsync(int id);
        void Update(Guardian guardian);
        void Remove(Guardian guardian);
    }
}