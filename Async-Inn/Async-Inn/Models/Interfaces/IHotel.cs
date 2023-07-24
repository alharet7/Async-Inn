

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        // Create 
        Task<Hotel> Create(Hotel hotel);

        // GET All
        Task<List<Hotel>> GetHotel();

        // GET Hotel By Id
        Task<Hotel> GetHotelById(int Id);

        // Update Hotel

        Task<Hotel> UpDateHotel(int Id, Hotel hotel);


        // Delete Hotel

        Task Delete(int Id);
    }
}
