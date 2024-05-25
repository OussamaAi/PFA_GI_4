using AuthSystem.Models;
using Microsoft.EntityFrameworkCore;
using PFA.Models;
using System.Collections.Generic;
namespace PFA.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Avis> Avis { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Chambre> Chambress { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Endroit> Endroits { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<LieuTouristique> LieuTouristiques { get; set; }
        public DbSet<Paiment> Paiments { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Restaurant>().HasBaseType<Endroit>();
            modelBuilder.Entity<Hotel>().HasBaseType<Endroit>();
            modelBuilder.Entity<LieuTouristique>().HasBaseType<Endroit>();


                    modelBuilder.Entity<Chambre>()
            .HasOne(c => c.reservation)
            .WithMany(r => r.chambres)
            .HasForeignKey(c => c.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Table>()
           .HasOne(c => c.Reservation) // Chaque chambre a une réservation
           .WithMany(r => r.tables) // Une réservation peut avoir plusieurs chambres
           .HasForeignKey(c => c.ReservationId) // La clé étrangère dans Chambress
           .OnDelete(DeleteBehavior.Restrict); // Suppression en cascade activée


            modelBuilder.Entity<Visit>()
            .HasOne(v => v.Endroit)
            .WithMany(e => e.Visits)
            .HasForeignKey(v => v.EndroitId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.User)
                .WithMany(c => c.Visits)
                .HasForeignKey(v => v.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
