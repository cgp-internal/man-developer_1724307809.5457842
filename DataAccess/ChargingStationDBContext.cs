using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class ChargingStationDBContext : DbContext
    {
        public ChargingStationDBContext(DbContextOptions<ChargingStationDBContext> options) : base(options)
        {
        }

        public DbSet<ChargingStation> ChargingStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=charging_station.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChargingStation>(entity =>
            {
                entity.ToTable("ChargingStations");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasColumnType("TEXT");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("TEXT");
            });
        }
    }
}