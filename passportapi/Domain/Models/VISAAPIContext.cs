using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace passportapi.Domain.Models
{
    public partial class VISAAPIContext : DbContext
    {
        public VISAAPIContext()
        {
        }

        public VISAAPIContext(DbContextOptions<VISAAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PassportInfo> PassportInfo { get; set; }
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
