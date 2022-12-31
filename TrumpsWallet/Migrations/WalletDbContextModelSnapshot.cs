﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrumpsWallet.DataAccess;

#nullable disable

namespace TrumpsWallet.Migrations
{
    [DbContext(typeof(WalletDbContext))]
    partial class WalletDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5172),
                            creationDate = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5177),
                            isBlocked = false,
                            money = 81000f,
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5189),
                            creationDate = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5190),
                            isBlocked = true,
                            money = 30000f,
                            userId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5192),
                            creationDate = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5192),
                            isBlocked = true,
                            money = 30000f,
                            userId = 3
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5194),
                            creationDate = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5194),
                            isBlocked = true,
                            money = 30000f,
                            userId = 4
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5196),
                            creationDate = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5196),
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
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(4878),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Usuario Cliente",
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(4883),
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
                            Date = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5228),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5226),
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
                            Date = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5234),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5233),
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
                            Date = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5237),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5236),
                            Type = "Topup",
                            toAccountID = 0,
                            userId = 1
                        },
                        new
                        {
                            Id = 4,
                            AccountID = 3,
                            Amount = 2000m,
                            Concept = "Transferencia",
                            Date = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5239),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5239),
                            Type = "Payment",
                            toAccountID = 1,
                            userId = 3
                        },
                        new
                        {
                            Id = 5,
                            AccountID = 4,
                            Amount = 2000m,
                            Concept = "Recarga",
                            Date = new DateTime(2022, 12, 29, 23, 29, 5, 740, DateTimeKind.Local).AddTicks(5241),
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5241),
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Franco44305@gmail.com",
                            FirstName = "Franco",
                            IsDeleted = false,
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5121),
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
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5125),
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
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5128),
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
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5129),
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
                            LastModified = new DateTime(2022, 12, 30, 2, 29, 5, 740, DateTimeKind.Utc).AddTicks(5133),
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
