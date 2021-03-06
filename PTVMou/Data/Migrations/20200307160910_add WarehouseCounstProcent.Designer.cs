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
    [Migration("20200307160910_add WarehouseCounstProcent")]
    partial class addWarehouseCounstProcent
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

                    b.Property<string>("Name");

                    b.HasKey("BattleСrewId");

                    b.ToTable("BattleСrew");
                });

            modelBuilder.Entity("Data.Entityes.BattleСrew_PTV", b =>
                {
                    b.Property<int>("BattleСrew_PTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BattleСrewId");

                    b.Property<int>("Count");

                    b.Property<int>("NeedPTV");

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

            modelBuilder.Entity("Data.Entityes.Norms", b =>
                {
                    b.Property<int>("NormsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NormsCount");

                    b.Property<int>("PTVId");

                    b.Property<decimal>("WarehouseCount");

                    b.HasKey("NormsId");

                    b.ToTable("Norms");
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

                    b.Property<string>("Name");

                    b.HasKey("ReserveId");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("Data.Entityes.ReservePTV", b =>
                {
                    b.Property<int>("ReservePTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("NeedPTV");

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

                    b.Property<int>("BattleСrewId");

                    b.Property<int>("CountCarInBattleCrew");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name");

                    b.Property<int>("ReservId");

                    b.Property<int?>("ReserveId");

                    b.HasKey("SubdivisionId");

                    b.HasIndex("BattleСrewId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ReserveId");

                    b.ToTable("Subdivision");
                });

            modelBuilder.Entity("Data.Entityes.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("Data.Entityes.Warehouse_PTV", b =>
                {
                    b.Property<int>("Warehouse_PTVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("NeedPTV");

                    b.Property<int>("PTVId");

                    b.Property<int?>("ReserveId");

                    b.Property<int>("WarehouseId");

                    b.HasKey("Warehouse_PTVId");

                    b.HasIndex("ReserveId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Warehouse_PTV");
                });

            modelBuilder.Entity("Data.Entityes.BattleСrew_PTV", b =>
                {
                    b.HasOne("Data.Entityes.BattleСrew", "BattleСrew")
                        .WithMany("BattleСrew_PTV")
                        .HasForeignKey("BattleСrewId")
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
                    b.HasOne("Data.Entityes.BattleСrew", "BattleСrew")
                        .WithMany()
                        .HasForeignKey("BattleСrewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entityes.Department", "Department")
                        .WithMany("Subdivision")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entityes.Reserve", "Reserve")
                        .WithMany()
                        .HasForeignKey("ReserveId");
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
