namespace Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        //Create Amenitie
        Task<Amenities> Create(Amenities amenities);

        //Get All Amenitie
        Task<List<Amenities>> GetAll();

        //Get Amenitie By Id
        Task<Amenities> GetAmenitiesById(int Id);

        //Update Amenitie
        Task<Amenities> UpdateAmenitie(int Id, Amenities amenities);

        //Delete Amenitie
        Task DeleteAmenitie(int Id);
    }
}
