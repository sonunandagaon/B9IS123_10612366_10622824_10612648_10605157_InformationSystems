using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicEquipmentStore.Models;

public partial class MusicEquipmentStoreContext : DbContext
{
    public MusicEquipmentStoreContext()
    {
    }

    public MusicEquipmentStoreContext(DbContextOptions<MusicEquipmentStoreContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<ProductTable> ProductTables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DGLDM4B\\MSSQLSERVER2019;Database=MusicEquipmentStore;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity.ToTable("Product_table");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Rating)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.IsRemember)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
