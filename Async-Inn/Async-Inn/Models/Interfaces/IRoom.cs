using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// Creates a new Room and adds it to the database. Returns the created RoomDTO with the generated ID and associated Amenities.
        /// </summary>
        /// <param name="NewRoomdto">The RoomDTO object representing the new Room to be created.</param>
        /// <returns>The newly created RoomDTO object with associated Amenities.</returns>
        Task<RoomDTO> Create(RoomDTO NewRoomdto);

        /// <summary>
        /// Retrieves a list of all Rooms from the database and returns them as a List of RoomDTO objects with associated Amenities.
        /// </summary>
        /// <returns>A List of RoomDTO objects representing all available Rooms with associated Amenities.</returns>
        Task<List<RoomDTO>> GetAll();

        /// <summary>
        /// Retrieves a specific Room from the database based on the provided ID and returns it as a RoomDTO object with associated Amenities.
        /// </summary>
        /// <param name="Id">The ID of the Room to retrieve.</param>
        /// <returns>A RoomDTO object representing the requested Room with associated Amenities if found; otherwise, returns null.</returns>
        Task<RoomDTO> GetRoom(int Id);

        /// <summary>
        /// Updates an existing Room in the database based on the provided ID and RoomDTO.
        /// Returns the updated RoomDTO if found; otherwise, returns null.
        /// </summary>
        /// <param name="Id">The ID of the Room to update.</param>
        /// <param name="room">The updated RoomDTO containing new data.</param>
        /// <returns>The updated RoomDTO if the Room is found; otherwise, returns null.</returns>
        Task<RoomDTO> UpdateRoom(int Id, RoomDTO room);

        /// <summary>
        /// Deletes an existing Room from the database based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the Room to be deleted.</param>
        Task DeleteRoom(int Id);

        /// <summary>
        /// Adds a new Amenity to the specified Room in the database.
        /// </summary>
        /// <param name="RoomId">The ID of the Room to which the Amenity will be added.</param>
        /// <param name="AmenityId">The ID of the Amenity to add to the Room.</param>
        Task AddAmenityToRoom(int RoomId, int AmenityId);

        /// <summary>
        /// Removes an existing Amenity from the specified Room in the database.
        /// </summary>
        /// <param name="RoomId">The ID of the Room from which the Amenity will be removed.</param>
        /// <param name="AmenityId">The ID of the Amenity to remove from the Room.</param>
        Task RemoveAmentityFromRoom(int RoomId, int AmenityId);
    }
}
