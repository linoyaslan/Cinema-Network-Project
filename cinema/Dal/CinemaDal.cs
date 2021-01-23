using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using cinema.Models;

namespace cinema.Dal
{

    public class CinemaDal : DbContext //class that works with SQL server
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("Movies"); //inside the ToTable is the name of the table in DB, Inside the Entity is the model name
            modelBuilder.Entity<Hall>().ToTable("Hall");
            modelBuilder.Entity<Screenings>().ToTable("Screenings");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Tickets>().ToTable("Tickets");
            modelBuilder.Entity<Cart>().ToTable("Cart");
        }
        public DbSet<Movies> movies { get; set; }
        public DbSet<Hall> hall { get; set; }
        public DbSet<Screenings> screenings { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Tickets> tickets { get; set; }
        public DbSet<Cart> cart { get; set; }
    }
}