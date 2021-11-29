using AutoMapper;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Resources;

namespace safeteefy_api.Shared.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveGuardianResource, Guardian>();
        }
    }
}