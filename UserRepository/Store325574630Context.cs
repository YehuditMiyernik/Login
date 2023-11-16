using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public partial class Store325574630Context : DbContext
{
    public Store325574630Context()
    {
    }

    public Store325574630Context(DbContextOptions<Store325574630Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E0FAPSB\\SQLEXPRESS;Database=Store325574630;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC074FB454CD");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF4B7D7BA9");

            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__UserId__5070F446");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC072D21BFE6");

            entity.ToTable("OrderItem");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__5441852A");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__534D60F1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07AEACFBC0");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ProdImage)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.ProdName)
                .HasMaxLength(30)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__267ABA7A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07328E97AF");

            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
