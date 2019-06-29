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
        public PassportInfoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PassportInfo>> ListAsync()
        {
            return await _context.PassportInfo.ToListAsync();
        }

        public async Task AddAsync(PassportInfo passportinfo)
        {
           await _context.PassportInfo.AddAsync(passportinfo);
        }

        public async Task<PassportInfo> FindByIdAsync(int id)
        {
           return await _context.PassportInfo.FindAsync(id);
        }

        public void Update(PassportInfo passportInfo)
        {
            _context.PassportInfo.Update(passportInfo);
        }

        public void Remove(PassportInfo passportInfo)
        {
            _context.PassportInfo.Remove(passportInfo);
        }

        public async Task<PassportInfo> GetBySourceAndDestination(string source, string destination)
        {
            var result = await _context.PassportInfo.SingleOrDefaultAsync(g => g.Passport == source && g.Destination == destination);
            return result;
        }

        public async Task<IEnumerable<PassportInfo>> GetBySingleCountry(string country)
        {
            var result = await _context.PassportInfo.Where(g => g.Passport == country).ToListAsync();
            return result;
        }
    }
}
    