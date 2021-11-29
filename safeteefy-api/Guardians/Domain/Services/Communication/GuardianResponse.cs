using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Shared.Domain.Services.Communication;

namespace safeteefy_api.Guardians.Domain.Services.Communication
{
    public class GuardianResponse : BaseResponse<Guardian>
    {
        public GuardianResponse(string message) : base(message)
        {
        }

        public GuardianResponse(Guardian resource) : base(resource)
        {
        }
    }
}