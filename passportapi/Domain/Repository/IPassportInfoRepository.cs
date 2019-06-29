using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Repository
{
    public interface IPassportInfoRepository
    {
        Task<IEnumerable<PassportInfo>> ListAsync();
        Task AddAsync(PassportInfo passportinfo);
        Task<PassportInfo> FindByIdAsync(int id);
        void Update(PassportInfo passportInfo);
        void Remove(PassportInfo passportInfo);
        Task<PassportInfo> GetBySourceAndDestination(string source, string destination);
        Task<IEnumerable<PassportInfo>> GetBySingleCountry(string country);
    }
}
