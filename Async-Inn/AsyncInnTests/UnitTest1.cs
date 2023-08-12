using Async_Inn.Controllers;
using Async_Inn.Models;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.Sqlite;
using Moq;
using System.Security.Claims;

namespace AsyncInnTests
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public async void CanEnrollAndDropARoom()
        {
            // Arrange
            var room = await CreatAndSaveRoomTest();
            var amenity = await CreatAndSaveAmenityTest();

            var roomAmenity = new RoomServices(_db, _amenity);

            // Act
            await roomAmenity.AddAmenityToRoom(room.Id, amenity.Id);


            // Assert
            var actualRoom = await roomAmenity.GetRoom(room.Id);

            Assert.Contains(actualRoom.Amenities, a => a.Id == amenity.Id);

            // Act
            // await roomAmenity.RemoveAmentityFromRoom(room.Id, amenity.Id);

            // Assert
            //actualRoom = await roomAmenity.GetRoom(room.Id);

            //Assert.DoesNotContain(actualRoom.Amenities, a => a.Id == amenity.Id);

        }
        [Fact]
        public async void Delete_Room_FromDataBase_Test()
        {
            // Arrange 
            var room = await DeleteAndSaveRoomTest();

            var service = new RoomServices(_db);

            // Act
            var deletedRoom = await service.GetRoom(room.Id);

            // Assert
            Assert.Null(deletedRoom);
        }

        [Fact]
        public async void GetAmenityById()
        {
            AmenityDTO Amenity = new AmenityDTO { Id = 4, Name = "TestAmenity1" };
            //AmenityDTO Amenity2 = new AmenityDTO { ID = 5, Name = "TestAmenity2" };

            var repository = new AmenityServices(_db);
            Amenity = await repository.Create(Amenity);

            var GetAmenity = await repository.GetAmenitiesById(4);

            Assert.Equal("TestAmenity1", GetAmenity.Name);
        }



        [Fact]
        public async void Create_Amenity_Test()
        {

            var amenity = new AmenityDTO()
            {
                Name = "Test1",
            };
            var service = new AmenityServices(_db);

            var add = await service.Create(amenity);

            Assert.NotNull(add);

        }

        [Fact]
        public async void Delete_Amenity_FromDataBase_Test()
        {
            // Arrange 
            var amenity = await DeleteAndSaveAmenityTest();

            var service = new AmenityServices(_db);

            // Act
            var deletedAmenity = await service.GetAmenitiesById(amenity.Id);

            // Assert
            Assert.Null(deletedAmenity);
        }

        [Fact]
        public async void DataSeedingTest_HotelDbSet()
        {
            //Arrange
            var hotels = new List<Hotel>
            {
            new Hotel { Id = 1, Name = "Lux Room", StreetAddress = "TV-Street", City = "Amman", Country = "Jordan", Phone = "0796153883", State = "Middle-East" },
            new Hotel { Id = 2, Name = "Grand Hotel", StreetAddress = "Central Avenue", City = "New York", Country = "USA", Phone = "1234567890", State = "North America" },
            new Hotel { Id = 3, Name = "Seaside Resort", StreetAddress = "Beach Road", City = "Sydney", Country = "Australia", Phone = "9876543210", State = "Oceania" }

            };

            var service = new HotelServices(_db);

            //Act
            var Hots = await service.GetHotel();
            Assert.Equal(hotels.Count, Hots.Count);
        }
        [Fact]
        public async Task Register_User_As_District_Manager()
        {
            // Arrange
            var userMock = new Mock<IUser>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(MockBehavior.Strict, null, null, null, null, null, null, null, null);
            var jwtTokenServiceMock = new Mock<JwtTokenService>(null, null);

            var roles = new List<Claim> { new Claim(ClaimTypes.Role, "District Manager") };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(roles));

            var controller = new UsersController(userMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = userPrincipal
                }
            };

            var registerDto = new RegisterUserDTO
            {
                Username = "TestUser",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                Password = "P@ssw0rd",
                Roles = new List<string> { "Agent" } // Adjust the roles as needed
            };

            var expectedResult = new UserDTO
            {
                Id = "UserId",
                Username = registerDto.Username,
                Token = "MockedToken",
                Roles = new List<string> { "Agent" } // Adjust the roles as needed
            };

            userMock.Setup(u => u.Register(It.IsAny<RegisterUserDTO>(), It.IsAny<ModelStateDictionary>(), It.IsAny<ClaimsPrincipal>()))
                            .ReturnsAsync(expectedResult);

            // Act
            var result = await controller.Register(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var userDto = Assert.IsType<UserDTO>(actionResult.Value);

            Assert.Equal(expectedResult.Username, userDto.Username);
            Assert.Equal(expectedResult.Roles, userDto.Roles);

        }
        [Fact]
        public async Task SignIn_User_Successfully()
        {
            // Arrange
            var expectedResult = new UserDTO
            {
                Id = "UserId",
                Username = "TestUser",
                Token = "MockedToken",
                Roles = new List<string> { "Agent" }
            };

            var userMock = SetupUserMock(expectedResult);
            var controller = new UsersController(userMock);

            var loginDto = new LoginDTO
            {
                Username = "TestUser",
                Password = "P@ssw0rd"
            };

            // Act
            var result = await controller.Login(loginDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var userDto = Assert.IsType<UserDTO>(actionResult.Value);

            Assert.Equal(expectedResult.Username, userDto.Username);
            Assert.Equal(expectedResult.Roles, userDto.Roles);
        }

    }
}