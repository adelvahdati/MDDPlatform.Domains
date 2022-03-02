using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDDPlatform.Domains.Infrastructure.Data.Configurations
{
    internal class WriteContextConfiguration : IEntityTypeConfiguration<Domain>,IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Domain> builder)
        {
            builder.HasKey(d=>d.Id);
            builder.Property(d=>d.Name);

            builder.Property(d=>d.ProblemDomain)
                    .HasConversion(p=> p.Id,id=> new ProblemDomain(id))
                    .HasColumnName("ProblemDomainId");

            builder.HasMany(d=>d.Models);

            builder.ToTable("Domains");                    
        }

        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(model=>model.TraceId).HasName("Id");
            builder.Property(model=>model.TraceId)
                    .HasConversion(traceId=> traceId.Value, id =>TraceId.Load(id))
                    .HasColumnName("Id");
            builder.Property(model=>model.Name);
            builder.Property(model=>model.Tag);
            builder.Property(model=> model.Type)
                    .HasConversion(type=> type.Value,value=>ModelType.Create(value))
                    .HasColumnName("Type");
            builder.Property(model=>model.Level);
            
            builder.ToTable("DomainModels");
        }
    }
}