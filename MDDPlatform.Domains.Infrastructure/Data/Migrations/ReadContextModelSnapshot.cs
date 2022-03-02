﻿// <auto-generated />
using System;
using MDDPlatform.Domains.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MDDPlatform.Domains.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ReadContext))]
    partial class ReadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MDDPlatform.Domains.Infrastructure.Data.Models.DomainData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProblemDomain")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProblemDomainId");

                    b.HasKey("Id");

                    b.ToTable("Domains", (string)null);
                });

            modelBuilder.Entity("MDDPlatform.Domains.Infrastructure.Data.Models.DomainModelData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DomainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("DomainModels", (string)null);
                });

            modelBuilder.Entity("MDDPlatform.Domains.Infrastructure.Data.Models.DomainModelData", b =>
                {
                    b.HasOne("MDDPlatform.Domains.Infrastructure.Data.Models.DomainData", "Domain")
                        .WithMany("DomainModels")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("MDDPlatform.Domains.Infrastructure.Data.Models.DomainData", b =>
                {
                    b.Navigation("DomainModels");
                });
#pragma warning restore 612, 618
        }
    }
}
