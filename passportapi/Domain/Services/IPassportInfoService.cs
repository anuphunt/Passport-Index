using passportapi.Domain.Models;
using passportapi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Services
{
    public interface IPassportInfoService
    {
        Task<IEnumerable<PassportInfo>> ListAsync();
        Task<PassportInfo> FindByIdAsync(int id);
        Task<PassportInfoResponse> SaveAsync(PassportInfo passportinfo);

        Task<PassportInfoResponse> UpdateAsync(int id, PassportInfo passportinfo);

        Task<PassportInfoResponse> DeleteAsync(int id);

        Task<PassportInfo> GetBySourceAndDestination(string sourceCountry, string destinationCountry);
    }
}
