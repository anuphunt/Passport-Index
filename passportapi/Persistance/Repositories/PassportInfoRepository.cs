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
    public class PassportInfoRepository : BaseRepository, IPassportInfoRepository
    {
        public PassportInfoRepository(PassportContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PassportIndex>> ListAsync()
        {
            return await _context.PassportIndex.ToListAsync();
        }

        public async Task AddAsync(PassportIndex passportinfo)
        {
           await _context.PassportIndex.AddAsync(passportinfo);
        }

        public async Task<PassportIndex> FindByIdAsync(int id)
        {
           return await _context.PassportIndex.FindAsync(id);
        }

        public void Update(PassportIndex passportIndex)
        {
            _context.PassportIndex.Update(passportIndex);
        }

        public void Remove(PassportIndex passportIndex)
        {
            _context.PassportIndex.Remove(passportIndex);
        }

        public async Task<PassportIndex> GetBySourceAndDestination(string source, string destination)
        {
            var result = await _context.PassportIndex.SingleOrDefaultAsync(g => g.Passport == source && g.Destination == destination);
            return result;
        }

        public async Task<IEnumerable<PassportIndex>> GetBySingleCountry(string country)
        {
            var result = await _context.PassportIndex.Where(g => g.Passport == country).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PassportIndex>> GetByCountryAndCode(string country, int code)
        {
            var result = await _context.PassportIndex.Where(g => g.Passport == country && g.Code == code).ToListAsync();
            return result;
        }
    }
}
    