using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrendyThreads.Models;

public partial class TrendyThreadsContext : DbContext
{
    public TrendyThreadsContext()
    {
    }

    public TrendyThreadsContext(DbContextOptions<TrendyThreadsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartClothing> CartClothings { get; set; }

    public virtual DbSet<Clothing> Clothings { get; set; }

    public virtual DbSet<ClothingColor> ClothingColors { get; set; }

    public virtual DbSet<ClothingSize> ClothingSizes { get; set; }

    public virtual DbSet<ClothingType> ClothingTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CS-05\\SQLEXPRESS04;Initial Catalog=TrendyThreads;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Cart_Clothing");
        });

        modelBuilder.Entity<CartClothing>(entity =>
        {
            entity.ToTable("CartClothing");

            entity.Property(e => e.CartClothingId).ValueGeneratedNever();

            entity.HasOne(d => d.Cart).WithMany(p => p.CartClothings)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartClothing_Cart");

            entity.HasOne(d => d.Clothing).WithMany(p => p.CartClothings)
                .HasForeignKey(d => d.ClothingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartClothing_Clothing");
        });

        modelBuilder.Entity<Clothing>(entity =>
        {
            entity.ToTable("Clothing");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ClothingColor).WithMany(p => p.Clothings)
                .HasForeignKey(d => d.ClothingColorId)
                .HasConstraintName("FK_Clothing_ClothingColor");

            entity.HasOne(d => d.ClothingSize).WithMany(p => p.Clothings)
                .HasForeignKey(d => d.ClothingSizeId)
                .HasConstraintName("FK_Clothing_Clothing");

            entity.HasOne(d => d.ClothingType).WithMany(p => p.Clothings)
                .HasForeignKey(d => d.ClothingTypeId)
                .HasConstraintName("FK_Clothing_ClothingType");
        });

        modelBuilder.Entity<ClothingColor>(entity =>
        {
            entity.ToTable("ClothingColor");

            entity.Property(e => e.Color).HasMaxLength(50);
        });

        modelBuilder.Entity<ClothingSize>(entity =>
        {
            entity.ToTable("ClothingSize");

            entity.Property(e => e.Size).HasMaxLength(50);
        });

        modelBuilder.Entity<ClothingType>(entity =>
        {
            entity.ToTable("ClothingType");

            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address1).HasMaxLength(50);
            entity.Property(e => e.Address2).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Zipcode).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
