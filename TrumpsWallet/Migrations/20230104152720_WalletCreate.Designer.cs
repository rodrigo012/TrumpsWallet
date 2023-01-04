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
    [Migration("20230104152720_WalletCreate")]
    partial class WalletCreate
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

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(963),
                            creationDate = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(967),
                            isBlocked = false,
                            money = 81000f,
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(982),
                            creationDate = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(983),
                            isBlocked = true,
                            money = 30000f,
                            userId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(984),
                            creationDate = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(984),
                            isBlocked = true,
                            money = 30000f,
                            userId = 3
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(985),
                            creationDate = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(985),
                            isBlocked = true,
                            money = 30000f,
                            userId = 4
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(986),
                            creationDate = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(986),
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Usuario Administrador",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(763),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Usuario Cliente",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(765),
                            Name = "Cliente"
                        });
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

                    b.Property<int>("toAccountID")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountID = 1,
                            Amount = 2000m,
                            Concept = "Transferencia",
                            Date = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1006),
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1006),
                            Type = "Payment",
                            toAccountID = 10,
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountID = 2,
                            Amount = 200m,
                            Concept = "Transferencia",
                            Date = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1012),
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1011),
                            Type = "Payment",
                            toAccountID = 3,
                            userId = 2
                        },
                        new
                        {
                            Id = 3,
                            AccountID = 1,
                            Amount = 150m,
                            Concept = "Recarga",
                            Date = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1013),
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1013),
                            Type = "Topup",
                            toAccountID = 0,
                            userId = 3
                        },
                        new
                        {
                            Id = 4,
                            AccountID = 3,
                            Amount = 2000m,
                            Concept = "Transferencia",
                            Date = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1015),
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1014),
                            Type = "Payment",
                            toAccountID = 1,
                            userId = 4
                        },
                        new
                        {
                            Id = 5,
                            AccountID = 4,
                            Amount = 2000m,
                            Concept = "Recarga",
                            Date = new DateTime(2023, 1, 4, 12, 27, 19, 628, DateTimeKind.Local).AddTicks(1016),
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(1016),
                            Type = "Topup",
                            toAccountID = 0,
                            userId = 4
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
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Franco44305@gmail.com",
                            FirstName = "Franco",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(885),
                            LastName = "Villarreal",
                            Password = "123456789",
                            Point = 7,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Yelfran@gmail.com",
                            FirstName = "Yelfran",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(887),
                            LastName = "Giuseppe",
                            Password = "Lion222",
                            Point = 5,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "RodrigoRoman@gmail.com",
                            FirstName = "Rodrigo",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(889),
                            LastName = "Roman",
                            Password = "LeoMessi2022",
                            Point = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "ManzanelliLuciano@gmail.com",
                            FirstName = "Luciano",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(890),
                            LastName = "Manzanelli",
                            Password = "LM1830",
                            Point = 6,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 5,
                            Email = "DaniDepablos@gmail.com",
                            FirstName = "Daniel",
                            IsDeleted = false,
                            LastModified = new DateTime(2023, 1, 4, 15, 27, 19, 628, DateTimeKind.Utc).AddTicks(890),
                            LastName = "Depablos",
                            Password = "Mango207",
                            Point = 3,
                            RoleId = 1
                        });
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

                    b.Navigation("Account");
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