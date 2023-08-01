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

        public async Task<HotelDTO> Create(HotelDTO hotel)
        {
            _hotel.Entry(hotel).State = EntityState.Added;

            await _hotel.SaveChangesAsync();

            HotelDTO hotelDTO = new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
            };

            return hotelDTO;
            //_hotel.Hotels.Add(hotel);
            //await _hotel.SaveChangesAsync();

            //return hotel;
        }

        public async Task Delete(int Id)
        {
            Hotel hotel = await _hotel.Hotels.FindAsync(Id);

            _hotel.Entry(hotel).State = EntityState.Deleted;

            await _hotel.SaveChangesAsync();

            //Hotel hotel = await GetHotelById(Id);
            //_hotel.Entry<Hotel>(hotel).State = EntityState.Deleted;

            //await _hotel.SaveChangesAsync();
        }



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

        public async Task<HotelDTO> UpDateHotel(int Id, HotelDTO hotel)
        {
            HotelDTO hotelDTO = new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
            };

            _hotel.Entry(hotel).State = EntityState.Modified;

            await _hotel.SaveChangesAsync();

            return hotelDTO;

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
