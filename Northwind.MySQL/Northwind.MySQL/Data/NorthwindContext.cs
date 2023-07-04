using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("alphabetical_list_of_products");

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(1)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasColumnType("int(1)");
            entity.Property(e => e.Discontinued).HasColumnType("int(1)");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(1)")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasColumnType("int(1)");
            entity.Property(e => e.QuantityPerUnit).HasColumnType("int(1)");
            entity.Property(e => e.ReorderLevel).HasColumnType("int(1)");
            entity.Property(e => e.SupplierId)
                .HasColumnType("int(1)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("int(1)");
            entity.Property(e => e.UnitsInStock).HasColumnType("int(1)");
            entity.Property(e => e.UnitsOnOrder).HasColumnType("int(1)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity
                .ToTable("categories")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CategoryName, "CategoryName").IsUnique();

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity
                .ToTable("customers")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.HasIndex(e => e.Region, "Region");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity
                .ToTable("employees")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.LastName, "LastName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.ReportsTo).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity
                .ToTable("orders")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CustomerId, "FK_CustomersOrders");

            entity.HasIndex(e => e.EmployeeId, "FK_EmployeesOrders");

            entity.HasIndex(e => e.OrderDate, "OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "ShippedDate");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShipVia).HasColumnType("int(11)");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomersOrders");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeesOrders");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("PRIMARY");

            entity
                .ToTable("orderdetails")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.OrderId, "FK_OrdersOrderDetails");

            entity.HasIndex(e => e.ProductId, "FK_ProductsOrderDetails");

            entity.Property(e => e.OrderDetailsId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderDetailsID");
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UnitPrice).HasPrecision(19, 4);

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersOrderDetails");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsOrderDetails");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity
                .ToTable("products")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CategoryId, "FK_ProductsCategories");

            entity.HasIndex(e => e.SupplierId, "FK_ProductsSuppliers");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Discontinued).HasDefaultValueSql("'0'");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ProductsCategories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_ProductsSuppliers");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("PRIMARY");

            entity
                .ToTable("shippers")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.ShipperId)
                .HasColumnType("int(11)")
                .HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity
                .ToTable("suppliers")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
