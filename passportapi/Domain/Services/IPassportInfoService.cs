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
        Task<IEnumerable<PassportIndex>> ListAsync();
        Task<PassportIndex> FindByIdAsync(int id);
        Task<PassportInfoResponse> SaveAsync(PassportIndex passportinfo);

        Task<PassportInfoResponse> UpdateAsync(int id, PassportIndex passportinfo);

        Task<PassportInfoResponse> DeleteAsync(int id);

        Task<PassportIndex> GetBySourceAndDestination(string sourceCountry, string destinationCountry);

        Task<IEnumerable<PassportIndex>> GetBySingleCountry(string country);

        Task<IEnumerable<PassportIndex>> GetByCountryAndCode(string country, int code);
    }
}
