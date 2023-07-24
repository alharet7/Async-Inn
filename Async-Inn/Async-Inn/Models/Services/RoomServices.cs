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
            var rooms = await _room.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> GetRoom(int Id)
        {
            Room room = await _room.Rooms.FindAsync(Id);
            return room;
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
    }
}
