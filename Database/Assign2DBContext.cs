using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Database
{
    public class Assign2DBContext : DbContext
    {
        public Assign2DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
