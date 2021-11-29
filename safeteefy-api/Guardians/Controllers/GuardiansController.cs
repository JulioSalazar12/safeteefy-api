using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Domain.Services;
using safeteefy_api.Guardians.Resources;
using safeteefy_api.Shared.Extensions;

namespace safeteefy_api.Guardians.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardiansController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly IMapper _mapper;

        public GuardiansController(IGuardianService guardianService, IMapper mapper)
        {
            _guardianService = guardianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GuardianResource>> GetAllAsync()
        {
            var guardians = await _guardianService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Guardian>, IEnumerable<GuardianResource>>(guardians);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveGuardianResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var guardian = _mapper.Map<SaveGuardianResource, Guardian>(resource);
            var result = await _guardianService.SaveAsync(guardian);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var guardianResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(guardianResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveGuardianResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var guardian = _mapper.Map<SaveGuardianResource, Guardian>(resource);
            var result = await _guardianService.UpdateAsync(id, guardian);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var guardianResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(guardianResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _guardianService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var guardianResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(guardianResource);
        }
    }
}