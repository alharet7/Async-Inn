using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AsyncInnTests
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;

        protected readonly AsyncInnDbContext _db;
        protected readonly IAmenity _amenity;
        protected readonly IRoom _room;
        protected readonly JwtTokenService _JwtTokenService;
        private readonly UserManager<ApplicationUser> userManager;

        protected readonly IUser _user;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                  new DbContextOptionsBuilder<AsyncInnDbContext>()
                  .UseSqlite(_connection).Options);

            _db.Database.EnsureCreated();

            _user = new IdentityUserService(userManager, _JwtTokenService);
        }

        protected async Task<Room> CreatAndSaveRoomTest()
        {
            var room = new Room() { Name = "RoomTest", Layout = 1 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.Id);
            return room;
        }

        protected async Task<Amenities> CreatAndSaveAmenityTest()
        {
            var amenity = new Amenities() { Name = "AmenityTest" };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.Id);
            return amenity;

        }

        protected async Task<Room> DeleteAndSaveRoomTest()
        {
            var room = new Room() { Id = 1, Name = "Test1", Layout = 1 };
            _db.Rooms.Remove(room);
            await _db.SaveChangesAsync();

            var deletedRoom = await _db.Rooms.FindAsync(room.Id);
            Assert.Null(deletedRoom);

            return room;
        }


        protected async Task<Amenities> DeleteAndSaveAmenityTest()
        {
            var amenity = new Amenities() { Id = 1, Name = "Test1" };
            _db.Amenities.Remove(amenity);
            await _db.SaveChangesAsync();

            var deletedAmenity = await _db.Amenities.FindAsync(amenity.Id);
            Assert.Null(deletedAmenity);

            return amenity;
        }
        protected static IUser SetupUserMock(UserDTO expectedResult)
        {
            var userMock = new Mock<IUser>();


            userMock.Setup(u => u.Authenticate(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expectedResult);

            return userMock.Object;
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
        // Test!!!
    }
}