using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDDPlatform.Domains.Infrastructure.Data.Configurations
{
    internal class WriteContextConfiguration : IEntityTypeConfiguration<Domain>,IEntityTypeConfiguration<DomainModel>
    {
        public void Configure(EntityTypeBuilder<Domain> builder)
        {
            builder.HasKey(d=>d.Id);
            builder.Property(d=>d.Name);

            builder.Property(d=>d.ProblemDomain)
                    .HasConversion(p=> p.Id,id=> new ProblemDomain(id))
                    .HasColumnName("ProblemDomainId");

            builder.HasMany(d=>d.DomainModels);

            builder.ToTable("Domains");                    
        }

        public void Configure(EntityTypeBuilder<DomainModel> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(dm=>dm.Name);
            builder.Property(dm=>dm.Tag);
            
            builder.ToTable("DomainModels");
        }
    }
}