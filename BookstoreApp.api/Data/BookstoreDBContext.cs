using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookstoreApp.api.Data
{
    public partial class BookstoreDBContext : DbContext
    {
        public BookstoreDBContext()
        {
        }

        public BookstoreDBContext(DbContextOptions<BookstoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=BookstoreDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.HasIndex(e => e.Isbn, "UQ__Table__447D36EAD5ABC104")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Table_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
