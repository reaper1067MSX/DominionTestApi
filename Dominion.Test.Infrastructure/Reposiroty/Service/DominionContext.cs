using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dominion.Test.Infrastructure.Entities;

namespace Dominion.Test.Infrastructure.Reposiroty.Service
{
    public partial class DominionContext : DbContext
    {
        public DominionContext()
        {
        }

        public DominionContext(DbContextOptions<DominionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual new DbSet<Model> Model { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => new { e.Location, e.Id })
                    .HasName("PK_Cars");

                entity.Property(e => e.Color).HasMaxLength(25).IsRequired();

                entity.Property(e => e.Milleage).HasColumnType("decimal(18, 2)").IsRequired();

                entity.Property(e => e.Model).HasMaxLength(10).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)").IsRequired();

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Enterprise");

                entity.HasOne(d => d.ModelNavigation)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => new { d.Location, d.Model })
                    .HasConstraintName("FK_Car_Model");
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => new { e.Location, e.Id });

                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Model_Enterprise");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
