using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Repository
{
    public interface IPassportInfoRepository
    {
        Task<IEnumerable<PassportIndex>> ListAsync();
        Task AddAsync(PassportIndex passportinfo);
        Task<PassportIndex> FindByIdAsync(int id);
        void Update(PassportIndex passportIndex);
        void Remove(PassportIndex passportIndex);
        Task<PassportIndex> GetBySourceAndDestination(string source, string destination);
        Task<IEnumerable<PassportIndex>> GetBySingleCountry(string country);
        Task<IEnumerable<PassportIndex>> GetByCountryAndCode(string countr, int code);
    }
}
