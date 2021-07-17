using CarParkSystem.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CarParkSystem.Core
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<ParkingArea> ParkingAreas { get; set; }

        public virtual DbSet<ParkedVehicle> ParkedVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////modelBuilder.Entity<ParkedVehicle>() instead of using two primary keys on single table we can create a unique key index  
            ////    .HasKey(e => new { e.VehicleNumber, e.ParkingAreaId });

            modelBuilder.Entity<ParkingArea>().HasData(new ParkingArea { ParkingAreaId = 1, NumberOfSpaces = 10});
            modelBuilder.Entity<ParkingArea>().HasData(new ParkingArea { ParkingAreaId = 2, NumberOfSpaces =15 });
            modelBuilder.Entity<ParkingArea>().HasData(new ParkingArea { ParkingAreaId = 3, NumberOfSpaces = 8 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder() //this class is defined in Configuration nuget package
                   .SetBasePath(Environment.CurrentDirectory) // this is defined in Configuration.Json package and remaining two nuget packages are reuired for EF operations
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
