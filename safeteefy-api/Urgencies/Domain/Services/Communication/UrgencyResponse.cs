using safeteefy_api.Shared.Domain.Services.Communication;
using safeteefy_api.Urgencies.Domain.Models;

namespace safeteefy_api.Urgencies.Domain.Services.Communication
{
    public class UrgencyResponse : BaseResponse<Urgency>
    {
        public UrgencyResponse(string message) : base(message)
        {
        }

        public UrgencyResponse(Urgency resource) : base(resource)
        {
        }
    }
}