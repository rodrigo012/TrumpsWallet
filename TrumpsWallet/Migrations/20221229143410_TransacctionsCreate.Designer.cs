﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrumpsWallet.DataAccess;

#nullable disable

namespace TrumpsWallet.Migrations
{
    [DbContext(typeof(WalletDbContext))]
    [Migration("20221229143410_TransacctionsCreate")]
    partial class TransacctionsCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrumpsWallet.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("bit");

                    b.Property<float>("money")
                        .HasColumnType("real");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1469),
                            creationDate = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1477),
                            isBlocked = false,
                            money = 81000f,
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1486),
                            creationDate = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1486),
                            isBlocked = true,
                            money = 30000f,
                            userId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1487),
                            creationDate = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1488),
                            isBlocked = true,
                            money = 30000f,
                            userId = 3
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1488),
                            creationDate = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1489),
                            isBlocked = true,
                            money = 30000f,
                            userId = 4
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1489),
                            creationDate = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1490),
                            isBlocked = false,
                            money = 15000f,
                            userId = 5
                        });
                });

            modelBuilder.Entity("TrumpsWallet.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("TrumpsWallet.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("toAccountID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.HasIndex("UserID");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountID = 1,
                            Amount = 2000m,
                            Concept = "Transferencia",
                            Date = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1599),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1598),
                            Type = "Payment",
                            UserID = 1,
                            toAccountID = 2
                        },
                        new
                        {
                            Id = 2,
                            AccountID = 2,
                            Amount = 200m,
                            Concept = "Transferencia",
                            Date = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1603),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1602),
                            Type = "Payment",
                            UserID = 2,
                            toAccountID = 5
                        },
                        new
                        {
                            Id = 3,
                            AccountID = 3,
                            Amount = 150m,
                            Concept = "Recarga",
                            Date = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1604),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1604),
                            Type = "Topup",
                            UserID = 3,
                            toAccountID = 2
                        },
                        new
                        {
                            Id = 4,
                            AccountID = 4,
                            Amount = 2000m,
                            Concept = "Transferencia",
                            Date = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1606),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1605),
                            Type = "Payment",
                            UserID = 4,
                            toAccountID = 1
                        },
                        new
                        {
                            Id = 5,
                            AccountID = 5,
                            Amount = 2000m,
                            Concept = "Recarga",
                            Date = new DateTime(2022, 12, 29, 11, 34, 10, 362, DateTimeKind.Local).AddTicks(1607),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 29, 14, 34, 10, 362, DateTimeKind.Utc).AddTicks(1606),
                            Type = "Topup",
                            UserID = 5,
                            toAccountID = 3
                        });
                });

            modelBuilder.Entity("TrumpsWallet.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrumpsWallet.Entities.Account", b =>
                {
                    b.HasOne("TrumpsWallet.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrumpsWallet.Entities.Transaction", b =>
                {
                    b.HasOne("TrumpsWallet.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrumpsWallet.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrumpsWallet.Entities.User", b =>
                {
                    b.HasOne("TrumpsWallet.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}