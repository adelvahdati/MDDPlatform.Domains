using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDDPlatform.Domains.Infrastructure.Data.Configurations 
{
    public class ReadContextConfiguration : IEntityTypeConfiguration<DomainData>, IEntityTypeConfiguration<DomainModelData>
    {
        public void Configure(EntityTypeBuilder<DomainData> builder)
        {
            builder.HasKey(d=>d.Id);
            builder.Property(d=>d.Name);
            builder.Property(d=>d.ProblemDomain)
                    .HasConversion(p=> p.Id,id=> new ProblemDomain(id))
                    .HasColumnName("ProblemDomainId");

            builder.HasMany(d=>d.DomainModels)
                    .WithOne(m=>m.Domain);

            builder.ToTable("Domains");                    
        }

        public void Configure(EntityTypeBuilder<DomainModelData> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(dm=>dm.Name);
            builder.Property(dm=>dm.Tag);

            builder.HasOne(dm=>dm.Domain)
                    .WithMany(d=>d.DomainModels);
            
            builder.ToTable("DomainModels");

        }

    }
}