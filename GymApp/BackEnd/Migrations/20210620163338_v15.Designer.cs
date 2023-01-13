﻿// <auto-generated />
using System;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20210620163338_v15")]
    partial class v15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Models.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int>("Godine")
                        .HasColumnType("int")
                        .HasColumnName("Godine");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KorisnickoIme");

                    b.Property<string>("PotvrdaSifre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PovrdaSifre");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<string>("RAND_SALT")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RAND_SALT");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sifra");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Slika");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefon");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<int>("tip")
                        .HasColumnType("int")
                        .HasColumnName("Tip");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("BackEnd.Models.ClanTeretane", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClanarinaID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int>("Godine")
                        .HasColumnType("int")
                        .HasColumnName("Godine");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KorisnickoIme");

                    b.Property<string>("PotvrdaSifre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PovrdaSifre");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<bool>("ProbniTermin")
                        .HasColumnType("bit")
                        .HasColumnName("ProbniTermin");

                    b.Property<string>("RAND_SALT")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RAND_SALT");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sifra");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Slika");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefon");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<float>("Tezina")
                        .HasColumnType("real")
                        .HasColumnName("Tezina");

                    b.Property<float>("Visina")
                        .HasColumnType("real")
                        .HasColumnName("Visina");

                    b.Property<int>("tip")
                        .HasColumnType("int")
                        .HasColumnName("Tip");

                    b.HasKey("ID");

                    b.HasIndex("ClanarinaID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("ClanTeretane");
                });

            modelBuilder.Entity("BackEnd.Models.Clanarina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DatumPoslednjegPlacanja")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DatumPoslednjegPlacanja");

                    b.Property<int>("Iznos")
                        .HasColumnType("int")
                        .HasColumnName("Iznos");

                    b.Property<bool>("Placena")
                        .HasColumnType("bit")
                        .HasColumnName("Placena");

                    b.HasKey("ID");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("BackEnd.Models.ClanoviTermini", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanoviId")
                        .HasColumnType("int");

                    b.Property<int>("TerminId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ClanoviTermini");
                });

            modelBuilder.Entity("BackEnd.Models.Obavestenje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sadrzaj");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Obavestenje");
                });

            modelBuilder.Entity("BackEnd.Models.Teretana", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("Teretana");
                });

            modelBuilder.Entity("BackEnd.Models.Termin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Datum")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Datum");

                    b.Property<string>("ImeTrenera")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImeTrenera");

                    b.Property<string>("KorisnickoImeTr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KorisnickoImeTr");

                    b.Property<int>("MaxOsoba")
                        .HasColumnType("int")
                        .HasColumnName("MaxOsoba");

                    b.Property<string>("NazivTreninga")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<string>("PrezimeTrenera")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PrezimeTrenera");

                    b.Property<int>("TrOsoba")
                        .HasColumnType("int")
                        .HasColumnName("TrOsoba");

                    b.Property<int?>("TreningID")
                        .HasColumnType("int");

                    b.Property<string>("VremeKraja")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VremeKraja");

                    b.Property<string>("VremePocetka")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VremePocetka");

                    b.HasKey("ID");

                    b.HasIndex("TreningID");

                    b.ToTable("Termin");
                });

            modelBuilder.Entity("BackEnd.Models.Trener", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int>("Godine")
                        .HasColumnType("int")
                        .HasColumnName("Godine");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KorisnickoIme");

                    b.Property<string>("PotvrdaSifre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PovrdaSifre");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<string>("RAND_SALT")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RAND_SALT");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sifra");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Slika");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefon");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<int>("tip")
                        .HasColumnType("int")
                        .HasColumnName("Tip");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Trener");
                });

            modelBuilder.Entity("BackEnd.Models.TreneriTreninzi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TrenerId")
                        .HasColumnType("int");

                    b.Property<int>("TreningId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TreneriTreninzi");
                });

            modelBuilder.Entity("BackEnd.Models.Trening", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int")
                        .HasColumnName("Cena");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tip");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Trening");
                });

            modelBuilder.Entity("BackEnd.Models.Zahtev", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanId")
                        .HasColumnType("int")
                        .HasColumnName("ClanId");

                    b.Property<string>("Datum")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Datum");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Opis");

                    b.Property<string>("Prihvacen")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prihvacen");

                    b.Property<int>("TrenerId")
                        .HasColumnType("int")
                        .HasColumnName("TrenerId");

                    b.Property<string>("TrenerIme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrenerIme");

                    b.Property<string>("TrenerPrezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrenerPrezime");

                    b.Property<int>("TreningId")
                        .HasColumnType("int")
                        .HasColumnName("TreningId");

                    b.Property<string>("VremeDo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VremeDo");

                    b.Property<string>("VremeOd")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VremeOd");

                    b.HasKey("ID");

                    b.HasIndex("TrenerId");

                    b.ToTable("Zahtev");
                });

            modelBuilder.Entity("BackEnd.Models.Administrator", b =>
                {
                    b.HasOne("BackEnd.Models.Teretana", "Teretana")
                        .WithMany("Administratori")
                        .HasForeignKey("TeretanaID");

                    b.Navigation("Teretana");
                });

            modelBuilder.Entity("BackEnd.Models.ClanTeretane", b =>
                {
                    b.HasOne("BackEnd.Models.Clanarina", "Clanarina")
                        .WithMany()
                        .HasForeignKey("ClanarinaID");

                    b.HasOne("BackEnd.Models.Teretana", "Teretana")
                        .WithMany("ClanoviTeretane")
                        .HasForeignKey("TeretanaID");

                    b.Navigation("Clanarina");

                    b.Navigation("Teretana");
                });

            modelBuilder.Entity("BackEnd.Models.Obavestenje", b =>
                {
                    b.HasOne("BackEnd.Models.Teretana", null)
                        .WithMany("Obavestenja")
                        .HasForeignKey("TeretanaID");
                });

            modelBuilder.Entity("BackEnd.Models.Termin", b =>
                {
                    b.HasOne("BackEnd.Models.Trening", null)
                        .WithMany("Termini")
                        .HasForeignKey("TreningID");
                });

            modelBuilder.Entity("BackEnd.Models.Trener", b =>
                {
                    b.HasOne("BackEnd.Models.Teretana", "Teretana")
                        .WithMany("Treneri")
                        .HasForeignKey("TeretanaID");

                    b.Navigation("Teretana");
                });

            modelBuilder.Entity("BackEnd.Models.Trening", b =>
                {
                    b.HasOne("BackEnd.Models.Teretana", "Teretana")
                        .WithMany("Treninzi")
                        .HasForeignKey("TeretanaID");

                    b.Navigation("Teretana");
                });

            modelBuilder.Entity("BackEnd.Models.Zahtev", b =>
                {
                    b.HasOne("BackEnd.Models.Trener", null)
                        .WithMany("Zahtevi")
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Models.Teretana", b =>
                {
                    b.Navigation("Administratori");

                    b.Navigation("ClanoviTeretane");

                    b.Navigation("Obavestenja");

                    b.Navigation("Treneri");

                    b.Navigation("Treninzi");
                });

            modelBuilder.Entity("BackEnd.Models.Trener", b =>
                {
                    b.Navigation("Zahtevi");
                });

            modelBuilder.Entity("BackEnd.Models.Trening", b =>
                {
                    b.Navigation("Termini");
                });
#pragma warning restore 612, 618
        }
    }
}
