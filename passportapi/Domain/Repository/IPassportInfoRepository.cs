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
    }
}
