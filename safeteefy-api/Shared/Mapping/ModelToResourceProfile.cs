using AutoMapper;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Resources;

namespace safeteefy_api.Shared.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Guardian, GuardianResource>();
        }
        
    }
}