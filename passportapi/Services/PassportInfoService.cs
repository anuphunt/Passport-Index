using passportapi.Domain.Models;
using passportapi.Domain.Repository;
using passportapi.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Services
{
    public class PassportInfoService: IPassportInfoService
    {
        private readonly IPassportInfoRepository _passportInfoRepository;

        public PassportInfoService(IPassportInfoRepository passportInfoRepository)
        {
            _passportInfoRepository = passportInfoRepository;
        }
        public async Task<IEnumerable<PassportInfo>> ListAsync()
        {
            return await _passportInfoRepository.ListAsync();
        }
    }
}
