using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using safeteefy_api.Urgencies.Domain.Models;
using safeteefy_api.Urgencies.Domain.Services;
using safeteefy_api.Urgencies.Resources;

namespace safeteefy_api.Guardians.Controllers
{
    [ApiController]
    [Route("api/guardians/{guardianId}/urgencies")]
    public class GuardianUrgenciesController : ControllerBase
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        
        public GuardianUrgenciesController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UrgencyResource>> GetAllByGuardianIdAsync(int guardianId)
        {
            var urgencies = await _urgencyService.ListByGuardianId(guardianId);
            var resource = _mapper.Map<IEnumerable<Urgency>, IEnumerable<UrgencyResource>>(urgencies);
            return resource;
        }
    }
}