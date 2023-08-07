using Async_Inn.Models.DTO;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// Creates a new Amenity and adds it to the database. Returns the created AmenityDTO with the generated ID.
        /// </summary>
        /// <param name="amenityDto">The AmenityDTO object representing the new Amenity to be created.</param>
        /// <returns>The newly created AmenityDTO object.</returns>
        Task<AmenityDTO> Create(AmenityDTO amenityDto);

        /// <summary>
        /// Retrieves a list of all Amenities from the database and returns them as a List of AmenityDTO objects.
        /// </summary>
        /// <returns>A List of AmenityDTO objects representing all available Amenities.</returns>
        Task<List<AmenityDTO>> GetAll();

        /// <summary>
        /// Retrieves a specific Amenity from the database based on the provided ID and returns it as an AmenityDTO object.
        /// </summary>
        /// <param name="Id">The ID of the Amenity to retrieve.</param>
        /// <returns>An AmenityDTO object representing the requested Amenity; null if not found.</returns>
        Task<AmenityDTO> GetAmenitiesById(int Id);

        /// <summary>
        /// Updates an existing Amenity in the database based on the provided ID and Amenities object.
        /// Returns the updated Amenity if found; otherwise, returns null.
        /// </summary>
        /// <param name="Id">The ID of the Amenity to update.</param>
        /// <param name="amenities">The updated Amenities object containing new data.</param>
        /// <returns>The updated Amenity; null if the Amenity with the given ID does not exist.</returns>
        Task<Amenities> UpdateAmenitie(int Id, Amenities amenities);

        /// <summary>
        /// Deletes an existing Amenity from the database based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the Amenity to be deleted.</param>
        Task DeleteAmenitie(int Id);
    }
}
