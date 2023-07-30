namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        // Create 
        Task<Room> Create(Room room);
        // GET All Rooms
        Task<List<Room>> GetAll();

        // GET Room By Id
        Task<Room> GetRoom(int Id);

        // Update Room
        Task<Room> UpdateRoom(int Id, Room room);

        // Delete Room
        Task DeleteRoom(int Id);


        Task AddAmenityToRoom(int RoomId, int AmenityId);

        Task RemoveAmentityFromRoom(int RoomId, int AmenityId);
    }
}
