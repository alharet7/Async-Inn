using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        // Create 
        Task<RoomDTO> Create(RoomDTO room);
        // GET All Rooms
        Task<List<RoomDTO>> GetAll();

        // GET Room By Id
        Task<RoomDTO> GetRoom(int Id);

        // Update Room
        Task<RoomDTO> UpdateRoom(int Id, RoomDTO room);

        // Delete Room
        Task DeleteRoom(int Id);


        Task AddAmenityToRoom(int RoomId, int AmenityId);

        Task RemoveAmentityFromRoom(int RoomId, int AmenityId);
    }
}
