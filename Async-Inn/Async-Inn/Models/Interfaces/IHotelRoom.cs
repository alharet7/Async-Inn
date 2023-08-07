using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {
        /// <summary>
        /// Creates a new HotelRoom and adds it to the database. Returns the created HotelRoomDTO with the generated ID and associated Hotel.
        /// </summary>
        /// <param name="hotelRoom">The HotelRoomDTO object representing the new HotelRoom to be created.</param>
        /// <param name="hotelId">The ID of the Hotel to which the HotelRoom will be associated.</param>
        /// <returns>The newly created HotelRoomDTO object with associated Hotel.</returns>
        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom, int hotelId);

        /// <summary>
        /// Retrieves a list of all HotelRooms for a specific Hotel from the database and returns them as a List of HotelRoomDTO objects.
        /// </summary>
        /// <param name="hotelId">The ID of the Hotel for which to retrieve all HotelRooms.</param>
        /// <returns>A List of HotelRoomDTO objects representing all available HotelRooms for the specified Hotel.</returns>
        Task<List<HotelRoomDTO>> GetAll(int hotelId);

        /// <summary>
        /// Retrieves a specific HotelRoom from the database based on the provided Hotel ID and Room Number and returns it as a HotelRoomDTO object.
        /// </summary>
        /// <param name="HotelId">The ID of the Hotel to which the HotelRoom belongs.</param>
        /// <param name="RoomNumber">The Room Number of the HotelRoom to retrieve.</param>
        /// <returns>A HotelRoomDTO object representing the requested HotelRoom if found; otherwise, returns null.</returns>
        Task<HotelRoomDTO> GetHotelRoomById(int HotelId, int RoomNumber);

        /// <summary>
        /// Updates an existing HotelRoom in the database based on the provided Hotel ID, Room Number, and HotelRoomDTO.
        /// Returns the updated HotelRoomDTO if found; otherwise, returns null.
        /// </summary>
        /// <param name="HotelId">The ID of the Hotel to which the HotelRoom belongs.</param>
        /// <param name="RoomNumber">The Room Number of the HotelRoom to update.</param>
        /// <param name="hotelRoom">The updated HotelRoomDTO containing new data.</param>
        /// <returns>The updated HotelRoomDTO if the HotelRoom is found; otherwise, returns null.</returns>
        Task<HotelRoomDTO> UpdateHotelRoom(int HotelId, int RoomNumber, HotelRoomDTO hotelRoom);

        /// <summary>
        /// Deletes an existing HotelRoom from the database based on the provided Hotel ID and Room Number.
        /// </summary>
        /// <param name="HotelId">The ID of the Hotel to which the HotelRoom belongs.</param>
        /// <param name="RoomNumber">The Room Number of the HotelRoom to be deleted.</param>
        Task DeleteHotelRoom(int HotelId, int RoomNumber);
    }
}
