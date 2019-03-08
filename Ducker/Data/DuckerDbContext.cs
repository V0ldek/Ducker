using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ducker.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ducker.Data
{
    public class DuckerDbContext : IdentityDbContext, IRepository
    {
        public DbSet<Duck> Ducks { get; set; }

        public DuckerDbContext(DbContextOptions<DuckerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Duck>(
                entity =>
                {
                    entity.HasKey(e => e.Name);

                    entity.Property(e => e.Name)
                        .HasMaxLength(32)
                        .IsRequired();
                    entity.Property(e => e.Color)
                        .IsRequired();
                    entity.Property(e => e.TimesSqueaked)
                        .HasDefaultValue(0)
                        .IsRequired();

                    entity.HasOne(e => e.User)
                        .WithMany()
                        .HasForeignKey(e => e.UserId);
                });
        }

        public Task SaveChangesAsync() => base.SaveChangesAsync();
    }
}
