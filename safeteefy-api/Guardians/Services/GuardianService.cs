using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Guardians.Domain.Repositories;
using safeteefy_api.Guardians.Domain.Services;
using safeteefy_api.Guardians.Domain.Services.Communication;
using safeteefy_api.Shared.Domain.Repositories;

namespace safeteefy_api.Guardians.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GuardianService(IGuardianRepository guardianRepository, IUnitOfWork unitOfWork)
        {
            _guardianRepository = guardianRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Guardian>> ListAsync()
        {
            return await _guardianRepository.ListAsync();
        }

        public async Task<Guardian> FindByIdAsync(int id)
        {
            return await _guardianRepository.FindByIdAsync(id);
        }

        public async Task<GuardianResponse> SaveAsync(Guardian guardian)
        {
            try
            {
                await _guardianRepository.AddAsync(guardian);
                await _unitOfWork.CompleteAsync();
                return new GuardianResponse(guardian);
            }
            catch (Exception e)
            {
                return new GuardianResponse($"Error occurred while saving guardian: {e.Message}");
            }
        }

        public async Task<GuardianResponse> UpdateAsync(int id, Guardian guardian)
        {
            var existingGuardian = await _guardianRepository.FindByIdAsync(id);
            if (existingGuardian == null)
            {
                return new GuardianResponse("Guardian not found");
            }

            existingGuardian.Username = guardian.Username;
            existingGuardian.Email = guardian.Email;
            existingGuardian.FirstName = guardian.FirstName;
            existingGuardian.LastName = guardian.LastName;
            existingGuardian.Gender = guardian.Gender;
            existingGuardian.Address = guardian.Address;
            
            try
            {
                _guardianRepository.Update(existingGuardian);
                await _unitOfWork.CompleteAsync();
                return new GuardianResponse(existingGuardian);
            }
            catch (Exception e)
            {
                return new GuardianResponse($"Error occurred while updating guardian: {e.Message}");
            }
        }

        public async Task<GuardianResponse> DeleteAsync(int id)
        {
            var existingGuardian = await _guardianRepository.FindByIdAsync(id);
            if (existingGuardian == null)
            {
                return new GuardianResponse("Guardian not found");
            }
            
            try
            {
                _guardianRepository.Remove(existingGuardian);
                await _unitOfWork.CompleteAsync();
                return new GuardianResponse(existingGuardian);
            }
            catch (Exception e)
            {
                return new GuardianResponse($"Error occurred while deleting guardian: {e.Message}");
            }
        }
    }
}