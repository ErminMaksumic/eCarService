using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eCarService.Database
{
    public partial class eCarServiceContext : DbContext
    {
        public eCarServiceContext()
        {
        }

        public eCarServiceContext(DbContextOptions<eCarServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; } = null!;
        public virtual DbSet<CarBrand> CarBrands { get; set; } = null!;
        public virtual DbSet<CarBrandOffer> CarBrandOffers { get; set; } = null!;
        public virtual DbSet<CarService> CarServices { get; set; } = null!;
        public virtual DbSet<CustomOfferRequest> CustomOfferRequests { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<OfferPart> OfferParts { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationsAdditionalService> ReservationsAdditionalServices { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=eCarService;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 1)");
            });

            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.CarService)
                    .WithMany(p => p.CarBrands)
                    .HasForeignKey(d => d.CarServiceId)
                    .HasConstraintName("FK_REFERENCE_24");
            });

            modelBuilder.Entity<CarBrandOffer>(entity =>
            {
                entity.ToTable("CarBrandOffer");

                entity.HasOne(d => d.CarBrand)
                    .WithMany(p => p.CarBrandOffers)
                    .HasForeignKey(d => d.CarBrandId)
                    .HasConstraintName("FK_REFERENCE_22");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.CarBrandOffers)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_REFERENCE_23");
            });

            modelBuilder.Entity<CarService>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(40);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.PhoneNumber).HasMaxLength(40);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CarServices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_REFERENCE_21");
            });

            modelBuilder.Entity<CustomOfferRequest>(entity =>
            {
                entity.HasKey(e => e.CustomReqId)
                    .HasName("PK_2");

                entity.ToTable("CustomOfferRequest");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Status).HasMaxLength(40);

                entity.HasOne(d => d.CarService)
                    .WithMany(p => p.CustomOfferRequests)
                    .HasForeignKey(d => d.CarServiceId)
                    .HasConstraintName("FK_REFERENCE_29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomOfferRequests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_REFERENCE_28");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.Status).HasMaxLength(40);

                entity.HasOne(d => d.CarService)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.CarServiceId)
                    .HasConstraintName("FK_REFERENCE_6");
            });

            modelBuilder.Entity<OfferPart>(entity =>
            {
                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.OfferParts)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_25");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.OfferParts)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_26");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.CarService)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.CarServiceId)
                    .HasConstraintName("FK_REFERENCE_17");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 1)");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(40);

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_REFERENCE_15");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_REFERENCE_16");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(40);

                entity.HasOne(d => d.CarBrand)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarBrandId)
                    .HasConstraintName("FK_REFERENCE_30");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_REFERENCE_14");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_REFERENCE_27");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_REFERENCE_5");
            });

            modelBuilder.Entity<ReservationsAdditionalService>(entity =>
            {
                entity.HasKey(e => e.ResAddServicesId)
                    .HasName("PK_13");

                entity.HasOne(d => d.AdditionalService)
                    .WithMany(p => p.ReservationsAdditionalServices)
                    .HasForeignKey(d => d.AdditionalServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_20");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationsAdditionalServices)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_19");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.PasswordHash).HasMaxLength(40);

                entity.Property(e => e.PasswordSalt).HasMaxLength(40);

                entity.Property(e => e.UserName).HasMaxLength(40);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_REFERENCE_18");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
