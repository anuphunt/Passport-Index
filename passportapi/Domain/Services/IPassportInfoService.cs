using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Services
{
    public interface IPassportInfoService
    {
        Task<IEnumerable<PassportInfo>> ListAsync();
    }
}
