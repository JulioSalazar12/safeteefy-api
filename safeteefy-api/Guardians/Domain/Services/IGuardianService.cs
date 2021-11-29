using System.Collections.Generic;
using System.Threading.Tasks;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Domain.Services.Communication;

namespace safeteefy_api.Guardians.Domain.Services
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> ListAsync();
        Task<Guardian> FindByIdAsync(int id);
        Task<GuardianResponse> SaveAsync(Guardian guardian);
        Task<GuardianResponse> UpdateAsync(int id, Guardian guardian);
        Task<GuardianResponse> DeleteAsync(int id);
    }
}