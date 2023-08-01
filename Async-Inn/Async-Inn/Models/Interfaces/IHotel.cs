

using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        // Create 
        Task<HotelDTO> Create(HotelDTO hotel);

        // GET All
        Task<List<HotelDTO>> GetHotel();

        // GET Hotel By Id
        Task<HotelDTO> GetHotelById(int Id);

        // Update Hotel

        Task<HotelDTO> UpDateHotel(int Id, HotelDTO hotel);


        // Delete Hotel

        Task Delete(int Id);
    }
}
