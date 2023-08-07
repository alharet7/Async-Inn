using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class HotelServices : IHotel
    {
        private readonly AsyncInnDbContext _hotel;

        public HotelServices(AsyncInnDbContext hotel)
        {
            _hotel = hotel;
        }

        /// <summary>
        /// Creates a new Hotel and adds it to the database. Returns the created Hotel entity.
        /// </summary>
        /// <param name="hotel">The Hotel entity representing the new hotel to be created.</param>
        /// <returns>The newly created Hotel entity.</returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            _hotel.Hotels.Add(hotel);
            await _hotel.SaveChangesAsync();

            return hotel;


            //Hotel hotelDTO = new()
            //{
            //    Id = hotel.Id,
            //    Name = hotel.Name,
            //    StreetAddress = hotel.StreetAddress,
            //    City = hotel.City,
            //    State = hotel.State,
            //    Phone = hotel.Phone,
            //};

            //_hotel.Entry(hotelDTO).State = EntityState.Added;
            //await _hotel.SaveChangesAsync();

            //return hotelDTO;

        }

        /// <summary>
        /// Deletes an existing Hotel from the database based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the Hotel to be deleted.</param>

        public async Task Delete(int Id)
        {
            Hotel hotel = await _hotel.Hotels.FindAsync(Id);

            _hotel.Entry(hotel).State = EntityState.Deleted;

            await _hotel.SaveChangesAsync();

            //Hotel hotel = await GetHotelById(Id);
            //_hotel.Entry<Hotel>(hotel).State = EntityState.Deleted;

            //await _hotel.SaveChangesAsync();
        }


        /// <summary>
        /// Retrieves a specific Hotel from the database based on the provided ID and returns it as a HotelDTO object.
        /// </summary>
        /// <param name="Id">The ID of the Hotel to retrieve.</param>
        /// <returns>A HotelDTO object representing the requested Hotel if found; otherwise, returns null.</returns>

        public async Task<HotelDTO> GetHotelById(int Id)
        {
            var hotel = await _hotel.Hotels.Select(
               hotel => new HotelDTO
               {
                   Id = hotel.Id,
                   Name = hotel.Name,
                   StreetAddress = hotel.StreetAddress,
                   City = hotel.City,
                   State = hotel.State,
                   Phone = hotel.Phone,
                   Room = hotel.hotelroom.Select(hotelR => new HotelRoomDTO
                   {
                       HotelId = hotelR.HotelId,
                       RoomNumber = hotelR.RoomNumber,
                       Rate = hotelR.Rate,
                       PetFriendly = hotelR.PetFriendly,
                       RoomID = hotelR.RoomID,
                       Room = new RoomDTO
                       {
                           Id = hotelR.room.Id,
                           Name = hotelR.room.Name,
                           Layout = hotelR.room.Layout,
                           Amenities = hotelR.room.RoomAmenities
                           .Select(A => new AmenityDTO
                           {
                               Id = A.Amenities.Id,
                               Name = A.Amenities.Name
                           }).ToList()
                       }
                   }).ToList()
               }).FirstOrDefaultAsync(h => h.Id == Id);
            return hotel;


            //Hotel hotel = await _hotel.Hotels.FindAsync(Id);

            //return hotel;
        }

        /// <summary>
        /// Retrieves a list of all Hotels from the database and returns them as a List of HotelDTO objects.
        /// </summary>
        /// <returns>A List of HotelDTO objects representing all available Hotels.</returns>

        public async Task<List<HotelDTO>> GetHotel()
        {

            return await _hotel.Hotels.Select(
                hotel => new HotelDTO
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone,
                    Room = hotel.hotelroom.Select(hotelR => new HotelRoomDTO
                    {
                        HotelId = hotelR.HotelId,
                        RoomNumber = hotelR.RoomNumber,
                        Rate = hotelR.Rate,
                        PetFriendly = hotelR.PetFriendly,
                        RoomID = hotelR.RoomID,
                        Room = new RoomDTO
                        {
                            Id = hotelR.room.Id,
                            Name = hotelR.room.Name,
                            Layout = hotelR.room.Layout,
                            Amenities = hotelR.room.RoomAmenities
                            .Select(A => new AmenityDTO
                            {
                                Id = A.Amenities.Id,
                                Name = A.Amenities.Name
                            }).ToList()
                        }
                    }).ToList()
                }).ToListAsync();
            //var hotel = await _hotel.Hotels.ToListAsync();

            //return hotel;
        }

        /// <summary>
        /// Updates an existing Hotel in the database based on the provided ID and Hotel entity.
        /// Returns the updated Hotel entity if found; otherwise, returns null.
        /// </summary>
        /// <param name="Id">The ID of the Hotel to update.</param>
        /// <param name="hotel">The updated Hotel entity containing new data.</param>
        /// <returns>The updated Hotel entity if the Hotel is found; otherwise, returns null.</returns>
        public async Task<Hotel> UpDateHotel(int Id, Hotel hotel)
        {
            hotel.Id = Id;
            _hotel.Entry<Hotel>(hotel).State = EntityState.Modified;

            await _hotel.SaveChangesAsync();

            return hotel;
            //Hotel hotelDTO = new()
            //{
            //    Id = hotel.Id,
            //    Name = hotel.Name,
            //    StreetAddress = hotel.StreetAddress,
            //    City = hotel.City,
            //    State = hotel.State,
            //    Phone = hotel.Phone,
            //};

            //_hotel.Entry(hotel).State = EntityState.Modified;

            //await _hotel.SaveChangesAsync();

            //return hotel;

            //var hotelValue = await _hotel.Hotels.FindAsync(Id);
            //if (hotelValue != null)
            //{
            //    hotelValue.Name = hotel.Name;
            //    hotelValue.State = hotel.State;
            //    hotelValue.Phone = hotel.Phone;
            //    hotelValue.StreetAddress = hotel.StreetAddress;
            //    hotelValue.City = hotel.City;
            //    hotelValue.Country = hotel.Country;

            //    await _hotel.SaveChangesAsync();
            //}
            //return hotelValue;

        }
    }
}
