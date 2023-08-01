using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {
        //Create HotelRoom
        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom, int hotelId);


        //Get All HotelRoom
        Task<List<HotelRoomDTO>> GetAll(int hotelId);

        //Get HotelRoom By Id
        Task<HotelRoomDTO> GetHotelRoomById(int HotelId, int RoomNumber);

        //Update HotelRoom
        Task<HotelRoomDTO> UpdateHotelRoom(int HotelId, int RoomNumber, HotelRoomDTO hotelRoom);

        //Delete HotelRoom
        Task DeleteHotelRoom(int HotelId, int RoomNumber);
    }
}
