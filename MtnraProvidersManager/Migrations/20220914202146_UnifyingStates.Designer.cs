﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MtnraProvidersManager_DAL.Data;

#nullable disable

namespace MtnraProvidersManager_PAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220914202146_UnifyingStates")]
    partial class UnifyingStates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.CommonRightContract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DirectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Year")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DirectionId");

                    b.ToTable("CommonRightContracts");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FieldOfActivity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsSme")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Direction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtendedName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("InterlocutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("InterlocutorId");

                    b.ToTable("Directions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a4889f52-a618-4d89-ae0d-3e109e1af171"),
                            Abbreviation = "DSI",
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5315),
                            ExtendedName = "Direction des Systèmes d'Information",
                            InterlocutorId = new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"),
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5323)
                        },
                        new
                        {
                            Id = new Guid("44348fb1-3c7e-42a7-afc4-76ee3940140b"),
                            Abbreviation = "DMA",
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5374),
                            ExtendedName = "Direction de la Modernisation de l'Administration",
                            InterlocutorId = new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"),
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5377)
                        },
                        new
                        {
                            Id = new Guid("8a9a5f15-b5f0-407b-8510-393b92f51a97"),
                            Abbreviation = "DRHF",
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5386),
                            ExtendedName = "Direction des Ressources Humaines et Financières",
                            InterlocutorId = new Guid("de194360-4865-4a95-a8fe-a28fc4168643"),
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5389)
                        },
                        new
                        {
                            Id = new Guid("6fa2d638-5793-4606-8d3b-dd75783177c0"),
                            Abbreviation = "DFP",
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5396),
                            ExtendedName = "Direction de la Fonction Publique",
                            InterlocutorId = new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"),
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5399)
                        },
                        new
                        {
                            Id = new Guid("15ad0f48-31e2-4741-900d-67cfa414cfa4"),
                            Abbreviation = "DECC",
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5408),
                            ExtendedName = "Direction des Études, de la Communication et de la Coopération",
                            InterlocutorId = new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"),
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5411)
                        });
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Interlocutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.ToTable("Interlocutors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"),
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4901),
                            FirstName = "Mohamed",
                            LastName = "MOUSSA",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4915)
                        },
                        new
                        {
                            Id = new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"),
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4954),
                            FirstName = "Jamal",
                            LastName = "SALAHEDDINE",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4964)
                        },
                        new
                        {
                            Id = new Guid("de194360-4865-4a95-a8fe-a28fc4168643"),
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4976),
                            FirstName = "Aziz",
                            LastName = "KHALLADI",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4986)
                        },
                        new
                        {
                            Id = new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"),
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5002),
                            FirstName = "Taoufik",
                            LastName = "AZARUAL",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5010)
                        },
                        new
                        {
                            Id = new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"),
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5016),
                            FirstName = "Sarah",
                            LastName = "LAMRANI",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5022)
                        });
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.InvitationToTender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DirectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExecutionLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasLaunched")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReservedForSme")
                        .HasColumnType("bit");

                    b.Property<int>("Nature")
                        .HasColumnType("int");

                    b.Property<string>("Object")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Trimester")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Year")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("DirectionId");

                    b.ToTable("InvitationsToTender");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Market", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DefinitiveReception")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DirectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Estimation")
                        .HasColumnType("float");

                    b.Property<DateTime>("LaunchedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nature")
                        .HasColumnType("int");

                    b.Property<string>("Object")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OriginalInvitationToTenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ProvisionalReception")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WarrantyDeadline")
                        .HasColumnType("datetime2");

                    b.Property<long>("Year")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DirectionId");

                    b.HasIndex("OriginalInvitationToTenderId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.MarketStateHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MarketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("MarketId");

                    b.ToTable("MarketsStateHistory");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.PurchaseOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DirectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Year")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DirectionId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4313),
                            FirstName = "Mock",
                            HashedPassword = "$2a$12$N1WBrH9z10xi1OSrcgvG..3xMyWIMgaaO.f6CcC.r33Nhzn4Mm4ve",
                            LastName = "Admin",
                            Role = "Admin",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4371),
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            AddedBy = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4404),
                            FirstName = "Mock",
                            HashedPassword = "$2a$12$G5zksm0jpyy63xRlG3NACuACiwJ13cX3uROX4UKrmVWI9lA4ZF60O",
                            LastName = "Moderator",
                            Role = "Moderator",
                            UpdatedOn = new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4415),
                            Username = "user"
                        });
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.CommonRightContract", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtnraProvidersManager_DAL.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Creator");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Company", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Direction", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Interlocutor", "Interlocutor")
                        .WithMany()
                        .HasForeignKey("InterlocutorId");

                    b.Navigation("Creator");

                    b.Navigation("Interlocutor");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Interlocutor", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.InvitationToTender", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Market", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtnraProvidersManager_DAL.Models.InvitationToTender", "OriginalInvitationToTender")
                        .WithMany()
                        .HasForeignKey("OriginalInvitationToTenderId");

                    b.Navigation("Company");

                    b.Navigation("Creator");

                    b.Navigation("Direction");

                    b.Navigation("OriginalInvitationToTender");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.MarketStateHistory", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Market", "Market")
                        .WithMany("StatesHistory")
                        .HasForeignKey("MarketId");

                    b.Navigation("Creator");

                    b.Navigation("Market");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.PurchaseOrder", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("MtnraProvidersManager_DAL.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Creator");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.User", b =>
                {
                    b.HasOne("MtnraProvidersManager_DAL.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("AddedBy");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("MtnraProvidersManager_DAL.Models.Market", b =>
                {
                    b.Navigation("StatesHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
