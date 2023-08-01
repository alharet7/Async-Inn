using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        //Create Amenitie
        Task<AmenityDTO> Create(AmenityDTO amenities);

        //Get All Amenitie
        Task<List<AmenityDTO>> GetAll();

        //Get Amenitie By Id
        Task<AmenityDTO> GetAmenitiesById(int Id);

        //Update Amenitie
        Task<AmenityDTO> UpdateAmenitie(int Id, AmenityDTO amenities);

        //Delete Amenitie
        Task DeleteAmenitie(int Id);
    }
}
