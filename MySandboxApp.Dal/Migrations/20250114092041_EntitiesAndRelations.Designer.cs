﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySandboxApp.Dal;

#nullable disable

namespace MySandboxApp.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250114092041_EntitiesAndRelations")]
    partial class EntitiesAndRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MySandboxApp.Dal.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("TotalCost")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.Order", b =>
                {
                    b.HasOne("MySandboxApp.Dal.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.OrderItem", b =>
                {
                    b.HasOne("MySandboxApp.Dal.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySandboxApp.Dal.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.Product", b =>
                {
                    b.HasOne("MySandboxApp.Dal.Entities.User", "Seller")
                        .WithMany("ProductsForSale")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MySandboxApp.Dal.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductsForSale");
                });
#pragma warning restore 612, 618
        }
    }
}
