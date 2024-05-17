using AuthSystem.Models;
using Microsoft.EntityFrameworkCore;
using PFA.Models;
using System.Collections.Generic;
namespace PFA.Context
{
    public class MyContext:DbContext
    {
        public DbSet<Avis> Avis { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Endroit> Endroits { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<LieuTouristique> LieuTouristiques { get; set; }
        public DbSet<Paiment> Paiments { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Ville> Ville { get; set; }


        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			 

            modelBuilder.Entity<Restaurant>().HasBaseType<Endroit>();
            modelBuilder.Entity<Hotel>().HasBaseType<Endroit>();
            modelBuilder.Entity<LieuTouristique>().HasBaseType<Endroit>();

        }
    }
}
