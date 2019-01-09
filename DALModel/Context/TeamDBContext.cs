using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DALModel
{
    public partial class TeamDBContext : DbContext
    {
        public TeamDBContext()
        {
        }

        public TeamDBContext(DbContextOptions<TeamDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TeamDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.18572.1");

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Players__TeamId__3B75D760");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
