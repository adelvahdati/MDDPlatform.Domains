using MDDPlatform.Domains.Infrastructure.Data.Configurations;
using MDDPlatform.Domains.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MDDPlatform.Domains.Infrastructure.Data.Context
{
    public class ReadContext : DbContext {
        public DbSet<DomainData> Domains {get;set;}
        public ReadContext(DbContextOptions<ReadContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadContextConfiguration();
            modelBuilder.ApplyConfiguration<DomainData>(configuration);
            modelBuilder.ApplyConfiguration<DomainModelData>(configuration);
        }

        
    }
}