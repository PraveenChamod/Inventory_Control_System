﻿// <auto-generated />
using System;
using Data_Access_Layer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240211083715_AddSaleOrderProductEntityToDatabase")]
    partial class AddSaleOrderProductEntityToDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data_Access_Layer.Entities.Category", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Employee", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Designation")
                        .HasColumnType("integer");

                    b.Property<string>("NIC")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<Guid?>("StoreId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Product", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.PurchaseOrder", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.SaleOrder", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.SaleOrderProduct", b =>
                {
                    b.Property<Guid?>("SaleOrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("SaleOrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleOrderProducts");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Store", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("StoreName")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Supplier", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("SupplierName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Employee", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("StoreId");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Product", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Data_Access_Layer.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Employee", "Employee")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Data_Access_Layer.Entities.Supplier", "Supplier")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Employee");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.SaleOrder", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Employee", "Employee")
                        .WithMany("SaleOrders")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.SaleOrderProduct", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Product", "Product")
                        .WithMany("SaleOrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.SaleOrder", "SaleOrder")
                        .WithMany("SaleOrderProducts")
                        .HasForeignKey("SaleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleOrder");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Employee", b =>
                {
                    b.Navigation("PurchaseOrders");

                    b.Navigation("SaleOrders");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Product", b =>
                {
                    b.Navigation("SaleOrderProducts");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.SaleOrder", b =>
                {
                    b.Navigation("SaleOrderProducts");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Store", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Supplier", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("PurchaseOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
