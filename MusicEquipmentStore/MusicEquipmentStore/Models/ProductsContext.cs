using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicEquipmentStore.Models;

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

        => optionsBuilder.UseSqlServer("Server=DESKTOP-DGLDM4B\\MSSQLSERVER2019;Database=Products;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Product_table");

            entity.Property(e => e.Image).HasColumnName("Image");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Name");
            entity.Property(e => e.Rating)
               .HasMaxLength(200)
               .IsUnicode(false)
               .HasColumnName("Rating");
            entity.Property(e => e.Price)
               .HasMaxLength(200)
               .IsUnicode(false)
               .HasColumnName("Price");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
