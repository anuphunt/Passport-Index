using Microsoft.EntityFrameworkCore;
using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Persistance.Contexts
{
    public class PassportContext : DbContext
    {
        public PassportContext(DbContextOptions options) : base(options){}

        public DbSet<PassportIndex> PassportIndex { get; set; }
    }
}