using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using global::IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.DAL
{
    public class RaceLeagueContext : IdentityDbContext<ApplicationUser>
    {
        public RaceLeagueContext(DbContextOptions<RaceLeagueContext> options)
            : base(options)
        {
        }
        public DbSet<Racer> Racers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<RacerTournament> RacerTournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Racer>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Tournament>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<RacerTournament>()
                .HasKey(rt => new { rt.RacerId, rt.TournamentId });


            // Racer Properties
            modelBuilder.Entity<Racer>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Racer>()
                .Property(r => r.Planet)
                .HasMaxLength(100);


            // Vehicle Properties
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Model)
                .HasMaxLength(100);


            // Tournament Properties
            modelBuilder.Entity<Tournament>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Tournament>()
                .Property(t => t.Location)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Tournament>()
                .Property(t => t.Status)
                .HasMaxLength(50);


            // One Vehicle has many Racers
            modelBuilder.Entity<Racer>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Racers)
                .HasForeignKey(r => r.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);


            // Racer and RacerTournament
            modelBuilder.Entity<RacerTournament>()
                .HasOne(rt => rt.Racer)
                .WithMany(r => r.RacerTournaments)
                .HasForeignKey(rt => rt.RacerId);


            // Tournament and RacerTournament
            modelBuilder.Entity<RacerTournament>()
                .HasOne(rt => rt.Tournament)
                .WithMany(t => t.RacerTournaments)
                .HasForeignKey(rt => rt.TournamentId);
        }
    }

}