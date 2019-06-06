using Microsoft.EntityFrameworkCore;
using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Persistance.Contexts
{
    public class AppDbContext: DbContext
    {
        public virtual DbSet<PassportInfo> PassportInfo { get; set; }

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public Task<IEnumerable<PassportInfo>> PassportInfo { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<PassportInfo>(entity =>
            {
                entity.ToTable("dataset");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
