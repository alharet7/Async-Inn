using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly AsyncInnDbContext _room;

        public RoomServices(AsyncInnDbContext room)
        {
            _room = room;
        }

        public async Task<Room> Create(Room room)
        {
            _room.Rooms.Add(room);
            await _room.SaveChangesAsync();
            return room;
        }

        public async Task DeleteRoom(int Id)
        {
            Room room = await GetRoom(Id);

            _room.Entry<Room>(room).State = EntityState.Deleted;

            await _room.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAll()
        {
            var Rooms = await _room.Rooms.Include(x => x.RoomAmenities).ThenInclude(y => y.Amenities).ToListAsync();
            return Rooms;
        }

        public async Task<Room> GetRoom(int Id)
        {
            var Room = await _room.Rooms.Include(x => x.RoomAmenities).ThenInclude(y => y.Amenities).FirstOrDefaultAsync(x => x.Id == Id);
            return Room;
        }

        public async Task<Room> UpdateRoom(int Id, Room room)
        {
            var roomValue = await _room.Rooms.FindAsync(Id);
            if (roomValue != null)
            {
                roomValue.Name = room.Name;
                roomValue.Layout = room.Layout;

                await _room.SaveChangesAsync();
            }
            return roomValue;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = new RoomAmenities
            {
                RoomID = roomId,
                AmenitiesId = amenityId

            };
            _room.Entry(roomAmenities).State = EntityState.Added;

            await _room.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = await _room.RoomAmenities
                                            .Where(Rm => Rm.RoomID == roomId && Rm.AmenitiesId == amenityId)
                                            .FirstAsync();
            _room.Entry(roomAmenity).State = EntityState.Deleted;
            _room.SaveChanges();
        }
    }
}
