using System.Collections.Generic;
using System.Threading.Tasks;
using safeteefy_api.Urgencies.Domain.Models;

namespace safeteefy_api.Urgencies.Domain.Repositories
{
    public interface IUrgencyRepository
    {
        Task<IEnumerable<Urgency>> ListAsync();
        Task<IEnumerable<Urgency>> FindByGuardianId(int id);
        Task AddAsync(Urgency urgency);
        Task<Urgency> FindByIdAsync(int id);
        void Update(Urgency urgency);
        void Remove(Urgency urgency);
    }
}