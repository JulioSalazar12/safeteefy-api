using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using safeteefy_api.Guardians.Domain.Repositories;
using safeteefy_api.Shared.Domain.Repositories;
using safeteefy_api.Urgencies.Domain.Models;
using safeteefy_api.Urgencies.Domain.Repositories;
using safeteefy_api.Urgencies.Domain.Services;
using safeteefy_api.Urgencies.Domain.Services.Communication;

namespace safeteefy_api.Urgencies.Services
{
    public class UrgencyService : IUrgencyService
    {
        private readonly IUrgencyRepository _urgencyRepository;
        private readonly IGuardianRepository  _guardianRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UrgencyService(IUrgencyRepository urgencyRepository, IUnitOfWork unitOfWork, IGuardianRepository guardianRepository)
        {
            _urgencyRepository = urgencyRepository;
            _unitOfWork = unitOfWork;
            _guardianRepository = guardianRepository;
        }
        
        public async Task<IEnumerable<Urgency>> ListAsync()
        {
            return await _urgencyRepository.ListAsync();
        }

        public async Task<IEnumerable<Urgency>> ListByGuardianId(int guardianId)
        {
            return await _urgencyRepository.FindByGuardianId(guardianId);
        }

        public async Task<Urgency> FindByIdAsync(int id)
        {
            return await _urgencyRepository.FindByIdAsync(id);
        }

        public async Task<UrgencyResponse> SaveAsync(Urgency urgency)
        {
            var existingGuardian = await _guardianRepository.FindByIdAsync(urgency.GuardianId);
            if (existingGuardian == null)
            {
                return new UrgencyResponse("Invalid guardian");
            }
            if (existingGuardian.FirstName.Length == 0 || existingGuardian.LastName.Length == 0)
            {
                return new UrgencyResponse("Firstname or Lastname of guardian is empty");
            }
            try
            {
                await _urgencyRepository.AddAsync(urgency);
                await _unitOfWork.CompleteAsync();
                return new UrgencyResponse(urgency);
            }
            catch (Exception e)
            {
                return new UrgencyResponse($"Error occurred while saving urgency: {e.Message}");
            }
        }

        public async Task<UrgencyResponse> UpdateAsync(int id, Urgency urgency)
        {
            var existingUrgency = await _urgencyRepository.FindByIdAsync(id);
            if (existingUrgency == null)
            {
                return new UrgencyResponse("Urgency not found");
            }
            var existingGuardian = await _guardianRepository.FindByIdAsync(urgency.GuardianId);
            if (existingGuardian == null)
            {
                return new UrgencyResponse("Invalid guardian");
            }

            existingUrgency.Title = urgency.Title;
            existingUrgency.Summary = urgency.Summary;
            existingUrgency.Latitude = urgency.Latitude;
            existingUrgency.Longitude = urgency.Longitude;
            existingUrgency.ReportedAt = urgency.ReportedAt;
            try
            {
                _urgencyRepository.Update(existingUrgency);
                await _unitOfWork.CompleteAsync();
                return new UrgencyResponse(existingUrgency);
            }
            catch (Exception e)
            {
                return new UrgencyResponse($"Error occurred while updating urgency: {e.Message}");
            }
        }

        public async Task<UrgencyResponse> DeleteAsync(int id)
        {
            var existingUrgency = await _urgencyRepository.FindByIdAsync(id);
            if (existingUrgency == null)
            {
                return new UrgencyResponse("Urgency not found");
            }
            try
            {
                _urgencyRepository.Remove(existingUrgency);
                await _unitOfWork.CompleteAsync();
                return new UrgencyResponse(existingUrgency);
            }
            catch (Exception e)
            {
                return new UrgencyResponse($"Error occurred while deleting urgency: {e.Message}");
            }
        }
    }
}