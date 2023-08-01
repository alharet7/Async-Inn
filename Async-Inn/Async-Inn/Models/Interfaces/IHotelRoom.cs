using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {
        //Create HotelRoom
        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom, int hotelId);


        //Get All HotelRoom
        Task<List<HotelRoomDTO>> GetAll();

        //Get HotelRoom By Id
        Task<HotelRoom> GetHotelRoomById(int HotelId, int RoomNumber);

        //Update HotelRoom
        Task<HotelRoom> UpdateHotelRoom(int HotelId, int RoomNumber, HotelRoomDTO hotelRoom);

        //Delete HotelRoom
        Task DeleteHotelRoom(int HotelId, int RoomNumber);
    }
}
