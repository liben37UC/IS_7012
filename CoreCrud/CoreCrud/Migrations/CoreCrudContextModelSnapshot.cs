﻿// <auto-generated />
using System;
using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCrud.Migrations
{
    [DbContext(typeof(CoreCrudContext))]
    partial class CoreCrudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCrud.Models.Collectible", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("Electronic");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Material");

                    b.Property<string>("Name");

                    b.Property<decimal>("Weight");

                    b.HasKey("ID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Collectible");
                });

            modelBuilder.Entity("CoreCrud.Models.Manufacturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ManufacturerName");

                    b.HasKey("ID");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("CoreCrud.Models.Collectible", b =>
                {
                    b.HasOne("CoreCrud.Models.Manufacturer", "Manufacturer")
                        .WithMany("Collectibles")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
