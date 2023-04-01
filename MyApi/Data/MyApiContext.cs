using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
{
    public class MyApiContext : DbContext
    {
        public MyApiContext (DbContextOptions<MyApiContext> options)
            : base(options)
        {

        }

       //protected override void OnConfiguring
       //(DbContextOptionsBuilder optionsBuilder)
       // {
       //     optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
       // }

        // One to Many
        public DbSet<MyApi.Models.Author> Author { get; set; } = default!;
        public DbSet<MyApi.Models.Book> Book { get; set; } = default!;


        // Many to Many
        public DbSet<MyApi.Models.Student> Student { get; set; } = default!;
        public DbSet<MyApi.Models.Course> Course { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many
            modelBuilder.Entity<Book>()
            .HasOne<Author>(book => book.Author)
            .WithMany(author => author.books)
            .HasForeignKey(k => k.AuthorId);


            // Many to Many

        }
    }
}
