using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        //Create Amenitie
        Task<AmenityDTO> Create(AmenityDTO amenityDto);

        //Get All Amenitie
        Task<List<AmenityDTO>> GetAll();

        //Get Amenitie By Id
        Task<AmenityDTO> GetAmenitiesById(int Id);

        //Update Amenitie
        Task<Amenities> UpdateAmenitie(int Id, Amenities amenities);

        //Delete Amenitie
        Task DeleteAmenitie(int Id);
    }
}
