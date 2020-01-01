using passportapi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PassportContext _context;

        public BaseRepository(PassportContext context)
        {
            _context = context;
        }
    }
}
