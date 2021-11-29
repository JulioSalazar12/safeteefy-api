using System.Collections.Generic;
using System.Threading.Tasks;
using safeteefy_api.Urgencies.Domain.Models;
using safeteefy_api.Urgencies.Domain.Services.Communication;

namespace safeteefy_api.Urgencies.Domain.Services
{
    public interface IUrgencyService
    {
        Task<IEnumerable<Urgency>> ListAsync();
        Task<IEnumerable<Urgency>> ListByGuardianId(int guardianId);
        Task<Urgency> FindByIdAsync(int id);
        Task<UrgencyResponse> SaveAsync(Urgency urgency);
        Task<UrgencyResponse> UpdateAsync(int id, Urgency urgency);
        Task<UrgencyResponse> DeleteAsync(int id);
    }
}