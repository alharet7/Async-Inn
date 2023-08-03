using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly AsyncInnDbContext _room;
        private readonly IAmenity _amenity;

        public RoomServices(AsyncInnDbContext room, IAmenity amenity)
        {
            _room = room;
            _amenity = amenity;
        }

        public async Task<RoomDTO> Create(AddNewRoomDTO room)
        {
            Room NewRoom = new()
            {
                Name = room.Name,
                Layout = room.Layout,
            };

            _room.Rooms.Entry(NewRoom).State = EntityState.Added;



            await _room.SaveChangesAsync();

            room.Id = NewRoom.Id;
            var getAmenity = await _amenity.GetAmenitiesById(room.AmenityID);

            await AddAmenityToRoom(room.Id, getAmenity.Id);
            
            RoomDTO dto = await GetRoom(room.Id);

            return dto;


            //RoomDTO roomDTO = new()
            //{
            //    Id = room.Id,
            //    Name = room.Name,
            //    Layout = room.Layout,
            //};

            //_room.Entry(room).State = EntityState.Added;

            //await _room.SaveChangesAsync();

            //return roomDTO;

            //_room.Rooms.Add(room);
            //await _room.SaveChangesAsync();
            //return room;
        }

        public async Task DeleteRoom(int Id)
        {
            Room room = await _room.Rooms.FindAsync(Id);

            _room.Entry(room).State = EntityState.Deleted;

            await _room.SaveChangesAsync();

            //Room room = await GetRoom(Id);

            //_room.Entry<Room>(room).State = EntityState.Deleted;

            //await _room.SaveChangesAsync();
        }

        public async Task<List<RoomDTO>> GetAll()
        {
            return await _room.Rooms.Select(r => new RoomDTO
            {
                Id = r.Id,
                Name = r.Name,
                Layout = r.Layout,
                Amenities = r.RoomAmenities.Select(a => new AmenityDTO
                {
                    Id = a.Amenities.Id,
                    Name = a.Amenities.Name
                }).ToList()
            }).ToListAsync();

            //var Rooms = await _room.Rooms.Include(x => x.RoomAmenities).ThenInclude(y => y.Amenities).ToListAsync();
            //return Rooms;
        }

        public async Task<RoomDTO> GetRoom(int Id)
        {
            var room = await _room.Rooms.Select(r => new RoomDTO
            {
                Id = r.Id,
                Name = r.Name,
                Layout = r.Layout,
                Amenities = r.RoomAmenities.Select(a => new AmenityDTO
                {
                    Id = a.Amenities.Id,
                    Name = a.Amenities.Name
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == Id);
            return room;

            //var Room = await _room.Rooms.Include(x => x.RoomAmenities).ThenInclude(y => y.Amenities).FirstOrDefaultAsync(x => x.Id == Id);
            //return Room;
        }

        public async Task<RoomDTO> UpdateRoom(int Id, RoomDTO room)
        {
            Room roomDTO = new()
            {
                Id = room.Id,
                Name = room.Name,
                Layout = room.Layout
            };

            _room.Entry(roomDTO).State = EntityState.Modified;

            await _room.SaveChangesAsync();

            return room;

            //var roomValue = await _room.Rooms.FindAsync(Id);
            //if (roomValue != null)
            //{
            //    roomValue.Name = room.Name;
            //    roomValue.Layout = room.Layout;

            //    await _room.SaveChangesAsync();
            //}
            //return roomValue;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {

            RoomAmenities newRoomAmenity = new()
            {
                RoomID = roomId,
                AmenitiesId = amenityId
            };
            _room.Entry(newRoomAmenity).State = EntityState.Added;
            await _room.SaveChangesAsync();


            //RoomAmenities roomAmenities = new RoomAmenities
            //{
            //    RoomID = roomId,
            //    AmenitiesId = amenityId

            //};
            //_room.Entry(roomAmenities).State = EntityState.Added;

            //await _room.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = _room.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenitiesId == amenityId);
            _room.Entry(removeAmentity).State = EntityState.Deleted;
            await _room.SaveChangesAsync();

            //RoomAmenities roomAmenity = await _room.RoomAmenities
            //                                .Where(Rm => Rm.RoomID == roomId && Rm.AmenitiesId == amenityId)
            //                                .FirstAsync();
            //_room.Entry(roomAmenity).State = EntityState.Deleted;
            //_room.SaveChanges();
        }
    }
}
