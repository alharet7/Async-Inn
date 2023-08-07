using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        /// <summary>
        /// Creates a new Hotel and adds it to the database. Returns the created Hotel entity.
        /// </summary>
        /// <param name="hotel">The Hotel entity representing the new hotel to be created.</param>
        /// <returns>The newly created Hotel entity.</returns>
        Task<Hotel> Create(Hotel hotel);

        /// <summary>
        /// Retrieves a list of all Hotels from the database and returns them as a List of HotelDTO objects.
        /// </summary>
        /// <returns>A List of HotelDTO objects representing all available Hotels.</returns>
        Task<List<HotelDTO>> GetHotel();

        /// <summary>
        /// Retrieves a specific Hotel from the database based on the provided ID and returns it as a HotelDTO object.
        /// </summary>
        /// <param name="Id">The ID of the Hotel to retrieve.</param>
        /// <returns>A HotelDTO object representing the requested Hotel if found; otherwise, returns null.</returns>
        Task<HotelDTO> GetHotelById(int Id);

        /// <summary>
        /// Updates an existing Hotel in the database based on the provided ID and Hotel entity.
        /// Returns the updated Hotel entity if found; otherwise, returns null.
        /// </summary>
        /// <param name="Id">The ID of the Hotel to update.</param>
        /// <param name="hotel">The updated Hotel entity containing new data.</param>
        /// <returns>The updated Hotel entity if the Hotel is found; otherwise, returns null.</returns>
        Task<Hotel> UpDateHotel(int Id, Hotel hotel);

        /// <summary>
        /// Deletes an existing Hotel from the database based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the Hotel to be deleted.</param>
        Task Delete(int Id);
    }
}
