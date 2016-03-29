﻿using Microsoft.Data.Entity;
// RC2 using Microsoft.EntityFrameworkCore;

namespace BooksSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\MSSQLLocalDb;database=Books;trusted_connection=true";
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);

        }
    }
}
