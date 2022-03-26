﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TriManiaContext))]
    partial class TriManiaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnName("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Neighborhood")
                        .HasColumnName("Neighborhood")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("State")
                        .HasColumnName("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Street")
                        .HasColumnName("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnName("CancelDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnName("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnName("FinishedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalValue")
                        .HasColumnName("TotalValue")
                        .HasColumnType("DECIMAL(15,2)");

                    b.Property<int?>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnName("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("DECIMAL(15,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnName("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("DECIMAL(15,2)");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnName("BirthDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cpf")
                        .HasColumnName("CPF")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnName("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnName("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Login")
                        .HasColumnName("Login")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Passworld")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<sbyte>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("TINYINT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(2022, 3, 26, 9, 27, 9, 168, DateTimeKind.Local).AddTicks(3202),
                            Cpf = "00000000000",
                            CreateDate = new DateTime(2022, 3, 26, 9, 27, 9, 169, DateTimeKind.Local).AddTicks(96),
                            Email = "admin@admin.com.br",
                            Login = "admin",
                            Name = "Admin",
                            Passworld = "BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413",
                            Type = (sbyte)1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
