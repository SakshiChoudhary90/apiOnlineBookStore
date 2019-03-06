using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiOnlineBookStoreProject.Models
{
    public class OnlineBookStoreAPIDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBiography> AuthorBiographies { get; set; }
        public DbSet<BookCategory> BookCategorys { get; set; }
        public DbSet<Book>Books { get; set; }
        public object Author { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TRD-512;Initial Catalog=apiOnlineBookStoredb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(a => a.BookCategory)
                .WithMany(b => b.Books)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
              .HasOne(a => a.Publication)
              .WithMany(b => b.Books)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
             .HasOne(a => a.Author)
             .WithMany(b => b.Books)
             .OnDelete(DeleteBehavior.SetNull);

        }

    }
}
