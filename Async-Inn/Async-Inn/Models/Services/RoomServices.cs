using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly AsyncInnDbContext _room;
        protected readonly IAmenity _amenity;

        public RoomServices(AsyncInnDbContext room, IAmenity amenity)
        {
            _room = room;
            _amenity = amenity;
        }
        public RoomServices(AsyncInnDbContext room)
        {
            _room = room;

        }
        /// <summary>
        /// Creates a new Room and adds it to the database. Returns the created RoomDTO with the generated ID and associated Amenities.
        /// </summary>
        /// <param name="room">The AddNewRoomDTO object representing the new Room to be created.</param>
        /// <returns>The newly created RoomDTO object with associated Amenities.</returns>
        public async Task<RoomDTO> Create(RoomDTO Newroom)
        {
            Room room = new Room
            {
                Name = Newroom.Name,
                Layout = Newroom.Layout

            };
            _room.Rooms.Entry(room).State = EntityState.Added;

            await _room.SaveChangesAsync();
            Newroom.Id = room.Id;

            return Newroom;
        }
        //public async Task<RoomDTO> Create(RoomDTO room)
        //{
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
        //}

        /// <summary>
        /// Deletes an existing Room from the database based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the Room to be deleted.</param>

        public async Task DeleteRoom(int Id)
        {
            Room room = await _room.Rooms.FindAsync(Id);

            _room.Entry(room).State = EntityState.Deleted;

            await _room.SaveChangesAsync();

            //Room room = await GetRoom(Id);

            //_room.Entry<Room>(room).State = EntityState.Deleted;

            //await _room.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a list of all Rooms from the database and returns them as a List of RoomDTO objects with associated Amenities.
        /// </summary>
        /// <returns>A List of RoomDTO objects representing all available Rooms with associated Amenities.</returns>

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

        /// <summary>
        /// Retrieves a specific Room from the database based on the provided ID and returns it as a RoomDTO object with associated Amenities.
        /// </summary>
        /// <param name="Id">The ID of the Room to retrieve.</param>
        /// <returns>A RoomDTO object representing the requested Room with associated Amenities if found; otherwise, returns null.</returns>

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

        /// <summary>
        /// Updates an existing Room in the database based on the provided ID and RoomDTO.
        /// Returns the updated RoomDTO if found; otherwise, returns null.
        /// </summary>
        /// <param name="Id">The ID of the Room to update.</param>
        /// <param name="room">The updated RoomDTO containing new data.</param>
        /// <returns>The updated RoomDTO if the Room is found; otherwise, returns null.</returns>

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

        /// <summary>
        /// Adds a new Amenity to the specified Room in the database.
        /// </summary>
        /// <param name="roomId">The ID of the Room to which the Amenity will be added.</param>
        /// <param name="amenityId">The ID of the Amenity to add to the Room.</param>

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

        /// <summary>
        /// Removes an existing Amenity from the specified Room in the database.
        /// </summary>
        /// <param name="roomId">The ID of the Room from which the Amenity will be removed.</param>
        /// <param name="amenityId">The ID of the Amenity to remove from the Room.</param>

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
