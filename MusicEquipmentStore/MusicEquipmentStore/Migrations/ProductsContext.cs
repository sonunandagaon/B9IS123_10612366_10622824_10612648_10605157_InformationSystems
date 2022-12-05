using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicEquipmentStore.Models;

namespace MusicEquipmentStore.Migrations;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductTable> ProductTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UDLAN01\\SQLEXPRESS;Database=Products;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product_table");

            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            entity.Property(e => e.Productimage).HasColumnName("productimage");
            entity.Property(e => e.Productname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("productname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
