using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelMNG.Models;

public partial class Qlks3Context : DbContext
{
    public Qlks3Context()
    {
    }

    public Qlks3Context(DbContextOptions<Qlks3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<BlogPost> BlogPosts { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Gallery> Galleries { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAmenity> RoomAmenities { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source= ADMIN-PC\\SQLEXPRESS; initial catalog=QLKS3; integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PK__Amenitie__842AF52BF64B079B");

            entity.Property(e => e.AmenityId)
                .ValueGeneratedNever()
                .HasColumnName("AmenityID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity.HasKey(e => e.BlogPostId).HasName("PK__BlogPost__32174149DAA63AC3");

            entity.Property(e => e.BlogPostId).HasColumnName("BlogPostID");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.BlogPosts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__BlogPosts__Categ__59C55456");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACDC722E415");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookings__UserID__1BC821DD");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B592C3977");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C6625BBA3B032B2");

            entity.Property(e => e.ContactId)
                .ValueGeneratedNever()
                .HasColumnName("ContactID");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gallery>(entity =>
        {
            entity.HasKey(e => e.GalleryId).HasName("PK__Gallery__CF4F7B957020B30B");

            entity.ToTable("Gallery");

            entity.Property(e => e.GalleryId)
                .ValueGeneratedNever()
                .HasColumnName("GalleryID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE2D24F9E2");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("ReviewID");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__1EA48E88");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__328639199920A269");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("RoomID");
            entity.Property(e => e.Bed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoomAmenity>(entity =>
        {
            entity.HasKey(e => e.RoomAmenityId).HasName("PK__RoomAmen__170ECC6C02D9C02A");

            entity.Property(e => e.RoomAmenityId)
                .ValueGeneratedNever()
                .HasColumnName("RoomAmenityID");
            entity.Property(e => e.AmenityId).HasColumnName("AmenityID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Amenity).WithMany(p => p.RoomAmenities)
                .HasForeignKey(d => d.AmenityId)
                .HasConstraintName("FK__RoomAmeni__Ameni__2645B050");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAmenities)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomAmeni__RoomI__25518C17");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC4E271ABA");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
