﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20200304182634_first time")]
    partial class firsttime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entityes.BattleСrew", b =>
                {
                    b.Property<int>("BattleСrewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SubdivisionId");

                    b.HasKey("BattleСrewId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("BattleСrew");
                });

            modelBuilder.Entity("Data.Entityes.BattleСrew_PTV", b =>
                {
                    b.Property<int>("BattleСrew_PTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BattleСrewId");

                    b.Property<int>("Count");

                    b.Property<int>("PTVId");

                    b.HasKey("BattleСrew_PTVId");

                    b.HasIndex("BattleСrewId");

                    b.ToTable("BattleСrew_PTV");
                });

            modelBuilder.Entity("Data.Entityes.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeDeparmen");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Data.Entityes.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Data.Entityes.PTV", b =>
                {
                    b.Property<int>("PTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Measure");

                    b.Property<string>("Name");

                    b.HasKey("PTVId");

                    b.ToTable("PTV");
                });

            modelBuilder.Entity("Data.Entityes.Reserve", b =>
                {
                    b.Property<int>("ReserveId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SubdivisionId");

                    b.Property<int>("WarehouseId");

                    b.HasKey("ReserveId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("Data.Entityes.ReservePTV", b =>
                {
                    b.Property<int>("ReservePTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("PTVId");

                    b.Property<int>("ReserveId");

                    b.HasKey("ReservePTVId");

                    b.HasIndex("ReserveId");

                    b.ToTable("ReservePTV");
                });

            modelBuilder.Entity("Data.Entityes.Subdivision", b =>
                {
                    b.Property<int>("SubdivisionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name");

                    b.HasKey("SubdivisionId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Subdivision");
                });

            modelBuilder.Entity("Data.Entityes.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SubdivisionId");

                    b.HasKey("WarehouseId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("Data.Entityes.Warehouse_PTV", b =>
                {
                    b.Property<int>("Warehouse_PTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("PTVId");

                    b.Property<int?>("ReserveId");

                    b.Property<int>("WarehouseId");

                    b.HasKey("Warehouse_PTVId");

                    b.HasIndex("ReserveId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Warehouse_PTV");
                });

            modelBuilder.Entity("Data.Entityes.BattleСrew", b =>
                {
                    b.HasOne("Data.Entityes.Subdivision", "Subdivision")
                        .WithMany()
                        .HasForeignKey("SubdivisionId");
                });

            modelBuilder.Entity("Data.Entityes.BattleСrew_PTV", b =>
                {
                    b.HasOne("Data.Entityes.BattleСrew", "BattleСrew")
                        .WithMany("BattleСrew_PTV")
                        .HasForeignKey("BattleСrewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.Reserve", b =>
                {
                    b.HasOne("Data.Entityes.Subdivision", "Subdivision")
                        .WithMany()
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.ReservePTV", b =>
                {
                    b.HasOne("Data.Entityes.Reserve", "Reserve")
                        .WithMany()
                        .HasForeignKey("ReserveId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.Subdivision", b =>
                {
                    b.HasOne("Data.Entityes.Department", "Department")
                        .WithMany("Subdivision")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.Warehouse", b =>
                {
                    b.HasOne("Data.Entityes.Subdivision", "Subdivision")
                        .WithMany()
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entityes.Warehouse_PTV", b =>
                {
                    b.HasOne("Data.Entityes.Reserve")
                        .WithMany("Warehouse_PTVs")
                        .HasForeignKey("ReserveId");

                    b.HasOne("Data.Entityes.Warehouse", "Warehouse")
                        .WithMany("Warehouse_PTVs")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
