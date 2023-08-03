

using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        // Create 
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
