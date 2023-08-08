using Async_Inn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() { Id = 1, Name = "Capital Hotel", StreetAddress = "King Abdullah St", City = "Amman", State = "Amman", Country = "Jordan", Phone = "00962786031935" },
                new Hotel() { Id = 2, Name = "Mountain Hotel", StreetAddress = "60th St", City = "AlSalt", State = "AlSalt", Country = "Jordan", Phone = "00962786031935" },
                new Hotel() { Id = 3, Name = "City Hotel", StreetAddress = "City Centre St", City = "Aqaba", State = "Aqaba", Country = "Jordan", Phone = "00962786031935" });

            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Name = "Studio", Layout = 0 },
                new Room() { Id = 2, Name = "Single Room", Layout = 1 },
                new Room() { Id = 3, Name = "Double Room", Layout = 2 });

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities() { Id = 1, Name = "Coffee Maker" },
                new Amenities() { Id = 2, Name = "AC" },
                new Amenities() { Id = 3, Name = "Sea View" });

            modelBuilder.Entity<HotelRoom>().HasKey(
               HotelRooms => new
               {
                   HotelRooms.HotelId,
                   HotelRooms.RoomID


               });

            modelBuilder.Entity<RoomAmenities>().HasKey(
                RoomAmenities => new
                {
                    RoomAmenities.AmenitiesId,
                    RoomAmenities.RoomID
                }
                );
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
