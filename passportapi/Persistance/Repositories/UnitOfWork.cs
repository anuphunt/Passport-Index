using passportapi.Domain.Repository;
using passportapi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Persistance.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly PassportContext _context; 
                
        public UnitOfWork(PassportContext context)
        {
            _context = context;
        }

        public  async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
