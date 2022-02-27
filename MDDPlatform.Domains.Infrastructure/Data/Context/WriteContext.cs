using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MDDPlatform.Domains.Infrastructure.Data.Context
{
    public class WriteContext : DbContext {
        public DbSet<Domain> Domains {get;set;}

        public WriteContext(DbContextOptions<WriteContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteContextConfiguration();
            modelBuilder.ApplyConfiguration<Domain>(configuration);
            modelBuilder.ApplyConfiguration<DomainModel>(configuration);

        }

    }
}