﻿// <auto-generated />
using System;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BikeStore.Models.Brand", b =>
                {
                    b.Property<int>("Brand_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Brand_id"));

                    b.Property<string>("Brand_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Product_id")
                        .HasColumnType("int");

                    b.HasKey("Brand_id");

                    b.HasIndex("Product_id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("BikeStore.Models.Category", b =>
                {
                    b.Property<int>("Category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Category_id"));

                    b.Property<string>("Category_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BikeStore.Models.Customer", b =>
                {
                    b.Property<int>("Customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Customer_id"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Customer_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("State")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Zip_code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Customer_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BikeStore.Models.Order", b =>
                {
                    b.Property<int>("Order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_id"));

                    b.Property<int?>("Customer_id")
                        .HasColumnType("int");

                    b.Property<string>("Order_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Order_status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Required_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shipped_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Staff_id")
                        .HasColumnType("int");

                    b.Property<int>("Store_id")
                        .HasColumnType("int");

                    b.HasKey("Order_id");

                    b.HasIndex("Customer_id");

                    b.HasIndex("Staff_id");

                    b.HasIndex("Store_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BikeStore.Models.Order_item", b =>
                {
                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<int>("Item_id")
                        .HasColumnType("int");

                    b.Property<int?>("Brand_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Descount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("List_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Order_id", "Item_id");

                    b.HasIndex("Brand_id");

                    b.HasIndex("Product_id");

                    b.ToTable("Order_items");
                });

            modelBuilder.Entity("BikeStore.Models.Product", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_id"));

                    b.Property<int>("Brand_id")
                        .HasColumnType("int");

                    b.Property<int>("Category_id")
                        .HasColumnType("int");

                    b.Property<decimal>("List_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Model_year")
                        .HasColumnType("smallint");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Product_id");

                    b.HasIndex("Brand_id");

                    b.HasIndex("Category_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BikeStore.Models.Staff", b =>
                {
                    b.Property<int>("Staff_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Staff_id"));

                    b.Property<byte>("Active")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Manager_id")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Staff_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Store_id")
                        .HasColumnType("int");

                    b.HasKey("Staff_id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Store_id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BikeStore.Models.Store", b =>
                {
                    b.Property<int>("Store_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Store_id"));

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("State")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Store_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Zip_code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Store_id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("BikeStore.Models.Brand", b =>
                {
                    b.HasOne("BikeStore.Models.Product", null)
                        .WithMany("Brands")
                        .HasForeignKey("Product_id");
                });

            modelBuilder.Entity("BikeStore.Models.Order", b =>
                {
                    b.HasOne("BikeStore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("Customer_id");

                    b.HasOne("BikeStore.Models.Staff", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("Staff_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStore.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("Store_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Staff");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BikeStore.Models.Order_item", b =>
                {
                    b.HasOne("BikeStore.Models.Brand", null)
                        .WithMany("Order_items")
                        .HasForeignKey("Brand_id");

                    b.HasOne("BikeStore.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BikeStore.Models.Product", b =>
                {
                    b.HasOne("BikeStore.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("Brand_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BikeStore.Models.Staff", b =>
                {
                    b.HasOne("BikeStore.Models.Store", "Store")
                        .WithMany("Staffs")
                        .HasForeignKey("Store_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BikeStore.Models.Brand", b =>
                {
                    b.Navigation("Order_items");
                });

            modelBuilder.Entity("BikeStore.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BikeStore.Models.Product", b =>
                {
                    b.Navigation("Brands");
                });

            modelBuilder.Entity("BikeStore.Models.Staff", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BikeStore.Models.Store", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}
