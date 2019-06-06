using Microsoft.EntityFrameworkCore;
using passportapi.Domain.Models;
using passportapi.Domain.Repository;
using passportapi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Persistance.Repositories
{
    public class PassportInfoRepository: BaseRepository, IPassportInfoRepository
    {
        public PassportInfoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PassportInfo>> ListAsync()
        {
            return await _context.PassportInfo.ToListAsync();
        }
    }
}
