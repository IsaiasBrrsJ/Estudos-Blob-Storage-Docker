﻿// <auto-generated />
using System;
using EstudiesDocker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstudiesDocker.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EstudiesDocker.Entites.Vehicle.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreationMethod")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FileName")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkPhoto")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Vehicles", (string)null);

                    b.HasDiscriminator<string>("CreationMethod");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EstudiesDocker.Entites.Vehicle.VehicleManual", b =>
                {
                    b.HasBaseType("EstudiesDocker.Entites.Vehicle.Vehicle");

                    b.Property<string>("ManualChange")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasDiscriminator().HasValue("Manual");
                });

            modelBuilder.Entity("EstudiesDocker.Entites.Vehicle.VehiclePlanned", b =>
                {
                    b.HasBaseType("EstudiesDocker.Entites.Vehicle.Vehicle");

                    b.HasDiscriminator().HasValue("Planned");
                });
#pragma warning restore 612, 618
        }
    }
}
