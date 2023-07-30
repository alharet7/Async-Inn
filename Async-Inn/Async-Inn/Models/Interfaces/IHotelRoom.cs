namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {
        //Create HotelRoom
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);


        //Get All HotelRoom
        Task<List<HotelRoom>> GetAll();

        //Get HotelRoom By Id
        Task<HotelRoom> GetHotelRoomById(int HotelId, int RoomNumber);

        //Update HotelRoom
        Task<HotelRoom> UpdateHotelRoom(int HotelId, int RoomNumber, HotelRoom hotelRoom);

        //Delete HotelRoom
        Task DeleteHotelRoom(int HotelId, int RoomNumber);
    }
}
