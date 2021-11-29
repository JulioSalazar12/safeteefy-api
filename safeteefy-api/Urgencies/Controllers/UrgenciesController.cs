using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Resources;
using safeteefy_api.Shared.Extensions;
using safeteefy_api.Urgencies.Domain.Models;
using safeteefy_api.Urgencies.Domain.Services;
using safeteefy_api.Urgencies.Resources;

namespace safeteefy_api.Urgencies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrgenciesController : ControllerBase
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;


        public UrgenciesController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UrgencyResource>> GetAllAsync()
        {
            var urgencies = await _urgencyService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Urgency>, IEnumerable<UrgencyResource>>(urgencies);
            return resource;
        }
        
        [HttpGet("{id}")]
        public async Task<UrgencyResource> GetByIdAsync(int id)
        {
            var urgency = await _urgencyService.FindByIdAsync(id);
            var resource = _mapper.Map<Urgency, UrgencyResource>(urgency);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUrgencyResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var urgency = _mapper.Map<SaveUrgencyResource, Urgency>(resource);
            var result = await _urgencyService.SaveAsync(urgency);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(result.Resource);
            return Ok(urgencyResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUrgencyResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var urgency = _mapper.Map<SaveUrgencyResource, Urgency>(resource);
            var result = await _urgencyService.UpdateAsync(id, urgency);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(result.Resource);
            return Ok(urgencyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _urgencyService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var urgencyResource = _mapper.Map<Urgency, UrgencyResource>(result.Resource);
            return Ok(urgencyResource);

        }

    }
}