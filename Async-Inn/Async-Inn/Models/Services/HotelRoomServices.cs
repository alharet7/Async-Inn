using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class HotelRoomServices : IHotelRoom

    {
        private readonly AsyncInnDbContext _context;

        private readonly IRoom _room;

        public HotelRoomServices(AsyncInnDbContext context , IRoom room)
        {
            _context = context;
            _room = room;
        }
        public async Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom, int hotelId)
        {
            

            HotelRoom newRoom = new()
            {
                HotelId = hotelId,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.RoomID,
                PetFriendly = hotelRoom.PetFriendly,
                RoomID = hotelRoom.RoomID
            };
            var room = await _room.GetRoom(newRoom.RoomID);
            if (room != null)
            {
                hotelRoom.Room = room;
                _context.Entry(newRoom).State = EntityState.Added;
                await _context.SaveChangesAsync();

                return hotelRoom;
            }

            else
            return null;


            //var room = await _context.Rooms.FindAsync(hotelRoom.RoomID);
            //var hotel = await _context.Hotels.FindAsync(hotelRoom.HotelId);

            //hotelRoom.HotelId = hotelId;

            //hotelRoom.room = room;
            //hotelRoom.hotel = hotel;

            //_context.HotelRooms.Add(hotelRoom);
            //await _context.SaveChangesAsync();
            //return hotelRoom;
        }

        public async Task DeleteHotelRoom(int HotelId, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelId == HotelId && hr.RoomNumber == RoomNumber)
                .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            //HotelRoom hotelRoom = await GetHotelRoomById(HotelId, RoomNumber);
            //if (hotelRoom != null)
            //{
            //    _context.HotelRooms.Remove(hotelRoom);
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task<List<HotelRoomDTO>> GetAll(int hotelId)
        {
            return await _context.HotelRooms
              .Where(hr => hr.HotelId == hotelId)
              .Select(hr => new HotelRoomDTO
              {
                  HotelId = hr.HotelId,
                  Rate = hr.Rate,
                  RoomID = hr.RoomID,
                  RoomNumber = hr.RoomNumber,
                  Room = new RoomDTO
                  {
                      Id = hr.room.Id,
                      Name = hr.room.Name,
                      Layout = hr.room.Layout,
                      Amenities = hr.room.RoomAmenities
                          .Select(a => new AmenityDTO
                          {
                              Id = a.Amenities.Id,
                              Name = a.Amenities.Name
                          }).ToList()
                  }
              }).ToListAsync();
            //var HotelRooms = await _context.HotelRooms.ToListAsync();
            //return HotelRooms;
        }

        public async Task<HotelRoomDTO> GetHotelRoomById(int HotelId, int RoomNumber)
        {
            var hotelroom = await _context.HotelRooms
               .Select(hr => new HotelRoomDTO
               {
                   HotelId = hr.HotelId,
                   Rate = hr.Rate,
                   RoomID = hr.RoomID,
                   RoomNumber = hr.RoomNumber,
                   Room = new RoomDTO
                   {
                       Id = hr.room.Id,
                       Name = hr.room.Name,
                       Layout = hr.room.Layout,
                       Amenities = hr.room.RoomAmenities
                           .Select(a => new AmenityDTO
                           {
                               Id = a.Amenities.Id,
                               Name = a.Amenities.Name
                           }).ToList()
                   }
               }).FirstOrDefaultAsync(x => x.HotelId == HotelId && x.RoomNumber == RoomNumber);
            return hotelroom;
            //var hotelRoom = await _context.HotelRooms.FindAsync(HotelId, RoomNumber);
            //return hotelRoom;
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int HotelId, int RoomNumber, HotelRoomDTO hr)
        {
            HotelRoom roomDetails = new HotelRoom
            {
                HotelId = HotelId,
                RoomNumber = RoomNumber,
                RoomID = hr.RoomID,
                Rate = hr.Rate,
                PetFriendly = hr.PetFriendly
            };

            _context.Entry(roomDetails).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hr;
            //HotelRoom CurrentHotelRoom = await GetHotelRoomById(HotelId, RoomNumber);


            //if (CurrentHotelRoom != null)
            //{

            //    CurrentHotelRoom.RoomNumber = updatedHotelRoom.RoomNumber;
            //    CurrentHotelRoom.RoomID = updatedHotelRoom.RoomID;
            //    CurrentHotelRoom.Rate = updatedHotelRoom.Rate;
            //    CurrentHotelRoom.PetFriendly = updatedHotelRoom.PetFriendly;
            //    await _context.SaveChangesAsync();

            //}
            //return CurrentHotelRoom;
        }
    }
}
