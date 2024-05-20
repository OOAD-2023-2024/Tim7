using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rent_a_car.Models;

namespace rent_a_car.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Vozilo> Vozila { get; set; }
        public DbSet<Account> Racuni { get; set; }
        public DbSet<Dostava> Dostave { get; set; }
        public DbSet<Dostavljac> Dostavljaci { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Placanje> Placanja { get; set; }
        public DbSet<Poslovnica> Poslovnice { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<PutnickoVozilo> PutnickaVozila { get; set; }
        public DbSet<TransportnoVozilo> TransportnaVozila { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vozilo>()
                .HasDiscriminator<string>("VoziloType")
                .HasValue<Vozilo>("Vozilo")
                .HasValue<TransportnoVozilo>("TransportnoVozilo")
                .HasValue<PutnickoVozilo>("PutnickoVozilo");

            modelBuilder.Entity<Account>().ToTable("Racun");
            modelBuilder.Entity<Dostava>().ToTable("Dostava");
            modelBuilder.Entity<Dostavljac>().ToTable("Dostavljac");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Placanje>().ToTable("Placanje");
            modelBuilder.Entity<Poslovnica>().ToTable("Poslovnica");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");

            base.OnModelCreating(modelBuilder);
        }
    }
}
