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

        // GET All
        Task<List<HotelDTO>> GetHotel();

        // GET Hotel By Id
        Task<HotelDTO> GetHotelById(int Id);

        // Update Hotel

        Task<Hotel> UpDateHotel(int Id, Hotel hotel);


        // Delete Hotel

        Task Delete(int Id);
    }
}
