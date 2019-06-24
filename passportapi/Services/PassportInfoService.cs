using passportapi.Domain.Models;
using passportapi.Domain.Repository;
using passportapi.Domain.Services;
using passportapi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Services
{
    public class PassportInfoService : IPassportInfoService
    {
        private readonly IPassportInfoRepository _passportInfoRepository;
        private readonly IUnitofWork _unitOfWork;
        public PassportInfoService(IPassportInfoRepository passportInfoRepository, IUnitofWork unitOfWork)
        {
            _passportInfoRepository = passportInfoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PassportInfo>> ListAsync()
        {
            return await _passportInfoRepository.ListAsync();
        }

        public async Task<PassportInfo> FindByIdAsync(int id)
        {
            return await _passportInfoRepository.FindByIdAsync(id);
        }

        public async Task<PassportInfoResponse> SaveAsync(PassportInfo passportInfo)
        {
            try
            {
                await _passportInfoRepository.AddAsync(passportInfo);
                await _unitOfWork.CompleteAsync();

                return new PassportInfoResponse(passportInfo);
            }
            catch (Exception ex)
            {
                return new PassportInfoResponse($"An Error occured when saving the Passport information: {ex.Message}");
            }
        }

        public async Task<PassportInfoResponse> UpdateAsync(int id, PassportInfo passportInfo)
        {
            var existingInfo = await _passportInfoRepository.FindByIdAsync(id);

            if (existingInfo == null)
            {
                return new PassportInfoResponse("Passport info not found.");
            }
            existingInfo.Passport = passportInfo.Passport;
            existingInfo.Destination = passportInfo.Destination;
            existingInfo.Value = passportInfo.Value;

            try
            {
                _passportInfoRepository.Update(existingInfo);
                await _unitOfWork.CompleteAsync();
                return new PassportInfoResponse(passportInfo);
            }

            catch (Exception ex)
            {
                return new PassportInfoResponse($"An error occured when updating the passport info: {ex.Message}");
            }
        }

        public async Task<PassportInfoResponse> DeleteAsync(int id)
        {
            var existingInfo = await _passportInfoRepository.FindByIdAsync(id);

            if (existingInfo == null)
                return new PassportInfoResponse("Passport Info not found");

            try
            {
                _passportInfoRepository.Remove(existingInfo);
                await _unitOfWork.CompleteAsync();

                return new PassportInfoResponse(existingInfo);
            }
            catch(Exception ex)
            {
                return new PassportInfoResponse($"An error occured when deleting the passport info: {ex.Message}");
            }
        }

        public async Task<PassportInfo> GetBySourceAndDestination(string sourceCountry, string destinationCountry)
        {
            return await _passportInfoRepository.GetBySourceAndDestination(sourceCountry, destinationCountry);
        }
    }
}
