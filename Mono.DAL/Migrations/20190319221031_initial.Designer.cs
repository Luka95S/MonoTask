﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mono.DAL;

namespace Mono.DAL.Migrations
{
    [DbContext(typeof(VehicleDBContext))]
    [Migration("20190319221031_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Mono")
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mono.DAL.DatabaseModels.VehicleMakeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abrv");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("Mono.DAL.DatabaseModels.VehicleModelModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abrv");

                    b.Property<string>("Name");

                    b.Property<Guid>("VehicleMakeId");

                    b.Property<Guid?>("VehicleMakesId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakesId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Mono.DAL.DatabaseModels.VehicleModelModel", b =>
                {
                    b.HasOne("Mono.DAL.DatabaseModels.VehicleMakeModel", "VehicleMakes")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakesId");
                });
#pragma warning restore 612, 618
        }
    }
}
