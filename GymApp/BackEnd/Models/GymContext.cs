using Microsoft.EntityFrameworkCore;
namespace BackEnd.Models
{
    public class GymContext:DbContext
    {
        public DbSet<Teretana> Teretana {get;set;}
        public DbSet<Administrator> Administratori{get;set;}
        public DbSet<Clanarina> Clanarine {get;set;}
        public DbSet<ClanTeretane> ClanoviTeretane{get;set;}
        public DbSet<Trener> Treneri{get;set;}
        public DbSet<Obavestenje> Obavestenja{get;set;}
        public DbSet<Termin> Termini {get;set;}
        public DbSet<Trening> Treninzi{get;set;}
        public DbSet<TreneriTreninzi> TreneriTreninzi {get;set;}
        public DbSet<ClanoviTermini> ClanoviTermini {get;set;}
        public DbSet<Zahtev> Zahtevi {get;set;}
    //    public DbSet<TreninziTrenera> TreninziTrenera{get;set;}
    //    public DbSet<TreneriTreninga> TreneriTreninga{get;set;}
        public GymContext(DbContextOptions options):base(options)
        {

        }

    }

}