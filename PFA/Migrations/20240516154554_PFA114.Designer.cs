﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PFA.Context;

#nullable disable

namespace PFA.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240516154554_PFA114")]
    partial class PFA114
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthSystem.Models.Avis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("AuthSystem.Models.Chambre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Disponibilité")
                        .HasColumnType("bit");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Prix")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Chambres");
                });

            modelBuilder.Entity("AuthSystem.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AuthSystem.Models.Endroit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Addresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Latitude")
                        .HasColumnType("int");

                    b.Property<int>("Longitude")
                        .HasColumnType("int");

                    b.Property<float>("NbrEtoile")
                        .HasColumnType("real");

                    b.Property<string>("NomEndroit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VilleId");

                    b.ToTable("Endroits");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Endroit");
                });

            modelBuilder.Entity("AuthSystem.Models.Paiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatePaiment")
                        .HasColumnType("datetime2");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("TypePaiment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Paiments");
                });

            modelBuilder.Entity("AuthSystem.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AuthSystem.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Nbr_Personnes")
                        .HasColumnType("int");

                    b.Property<int>("Numéro")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<bool>("libre")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("AuthSystem.Models.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ville");
                });

            modelBuilder.Entity("PFA.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthSystem.Models.Hotel", b =>
                {
                    b.HasBaseType("AuthSystem.Models.Endroit");

                    b.Property<int>("NbrCHambre")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Hotel");
                });

            modelBuilder.Entity("AuthSystem.Models.LieuTouristique", b =>
                {
                    b.HasBaseType("AuthSystem.Models.Endroit");

                    b.Property<DateTime>("DateFermeture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOuverture")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("LieuTouristique");
                });

            modelBuilder.Entity("AuthSystem.Models.Restaurant", b =>
                {
                    b.HasBaseType("AuthSystem.Models.Endroit");

                    b.Property<DateTime?>("HeureFermeture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HeureOuverture")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeCuisine")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Restaurant");
                });

            modelBuilder.Entity("AuthSystem.Models.Avis", b =>
                {
                    b.HasOne("PFA.Models.User", "user")
                        .WithMany("Avis")
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("AuthSystem.Models.Chambre", b =>
                {
                    b.HasOne("AuthSystem.Models.Hotel", "hotel")
                        .WithMany("Chambres")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthSystem.Models.Reservation", "reservation")
                        .WithMany("chambres")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("AuthSystem.Models.Contact", b =>
                {
                    b.HasOne("PFA.Models.User", "user")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AuthSystem.Models.Endroit", b =>
                {
                    b.HasOne("AuthSystem.Models.Ville", "ville")
                        .WithMany("Endroit")
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ville");
                });

            modelBuilder.Entity("AuthSystem.Models.Paiment", b =>
                {
                    b.HasOne("AuthSystem.Models.Reservation", "reservation")
                        .WithMany("paiments")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("AuthSystem.Models.Reservation", b =>
                {
                    b.HasOne("PFA.Models.User", "user")
                        .WithMany("Reservations")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AuthSystem.Models.Table", b =>
                {
                    b.HasOne("AuthSystem.Models.Reservation", "Reservation")
                        .WithMany("tables")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthSystem.Models.Restaurant", null)
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("AuthSystem.Models.Reservation", b =>
                {
                    b.Navigation("chambres");

                    b.Navigation("paiments");

                    b.Navigation("tables");
                });

            modelBuilder.Entity("AuthSystem.Models.Ville", b =>
                {
                    b.Navigation("Endroit");
                });

            modelBuilder.Entity("PFA.Models.User", b =>
                {
                    b.Navigation("Avis");

                    b.Navigation("Contacts");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AuthSystem.Models.Hotel", b =>
                {
                    b.Navigation("Chambres");
                });

            modelBuilder.Entity("AuthSystem.Models.Restaurant", b =>
                {
                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
