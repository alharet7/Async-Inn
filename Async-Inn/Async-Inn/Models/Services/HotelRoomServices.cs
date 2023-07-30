using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class HotelRoomServices : IHotelRoom

    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
        {
            var room = await _context.Rooms.FindAsync(hotelRoom.RoomID);
            var hotel = await _context.Hotels.FindAsync(hotelRoom.HotelId);

            hotelRoom.HotelId = hotelId;

            hotelRoom.room = room;
            hotelRoom.hotel = hotel;

            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
        /* var room = await _context.Room.FindAsync(hotelRoom.RoomID);
            var hotel = await _context.Hotel.FindAsync(hotelRoom.HotelID);
            
            hotelRoom.HotelID = hotelId;
            
            hotelRoom.Room = room;
            hotelRoom.Hotel = hotel;

            _context.HotelRooms.Add(hotelRoom);

            await _context.SaveChangesAsync();

            return hotelRoom;*/
        public async Task DeleteHotelRoom(int HotelId, int RoomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoomById(HotelId, RoomNumber);
            if (hotelRoom != null)
            {
                _context.HotelRooms.Remove(hotelRoom);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HotelRoom>> GetAll()
        {
            var HotelRooms = await _context.HotelRooms.ToListAsync();
            return HotelRooms;
        }

        public async Task<HotelRoom> GetHotelRoomById(int HotelId, int RoomNumber)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(HotelId, RoomNumber);
            return hotelRoom;
        }

        public async Task<HotelRoom> UpdateHotelRoom(int HotelId, int RoomNumber, HotelRoom updatedHotelRoom)
        {
            HotelRoom CurrentHotelRoom = await GetHotelRoomById(HotelId, RoomNumber);


            if (CurrentHotelRoom != null)
            {

                CurrentHotelRoom.RoomNumber = updatedHotelRoom.RoomNumber;
                CurrentHotelRoom.RoomID = updatedHotelRoom.RoomID;
                CurrentHotelRoom.Rate = updatedHotelRoom.Rate;
                CurrentHotelRoom.PetFriendly = updatedHotelRoom.PetFriendly;
                await _context.SaveChangesAsync();

            }
            return CurrentHotelRoom;
        }
    }
}
