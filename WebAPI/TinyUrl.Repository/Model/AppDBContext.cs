using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Repository.Model
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<TinyUrl> TinyUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TinyUrl>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);

                // Identity / Auto Increment
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                // Required fields
                entity.Property(e => e.OriginalUrl)
                      .IsRequired()
                      .HasMaxLength(2048);

                entity.Property(e => e.ShortCode)
                      .IsRequired()
                      .HasMaxLength(10);

                // Unique ShortCode
                entity.HasIndex(e => e.ShortCode)
                      .IsUnique();

                entity.Property(e => e.TotalClickCount)
                      .HasDefaultValue(0);
            });
        }
    }
 }
