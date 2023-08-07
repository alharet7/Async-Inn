using Async_Inn.Data;
using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class AmenityServices : IAmenity
    {
        private readonly AsyncInnDbContext _amenity;

        public AmenityServices(AsyncInnDbContext amenity)
        {
            _amenity = amenity;
        }


        /// <summary>
        /// Creates a new Amenity and adds it to the database. Returns the created AmenityDTO with the generated ID.
        /// </summary>
        /// <param name="amenityDto">The AmenityDTO object representing the new Amenity to be created.</param>
        /// <returns>The newly created AmenityDTO object.</returns>
        public async Task<AmenityDTO> Create(AmenityDTO amenityDto)
        {

            Amenities amenity = new()
            {
                Id = amenityDto.Id,
                Name = amenityDto.Name
            };
            _amenity.Entry(amenity).State = EntityState.Added;

            await _amenity.SaveChangesAsync();
            amenityDto.Id = amenity.Id;

            return amenityDto;

        }

        /// <summary>
        /// Deletes an existing Amenity from the database based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the Amenity to be deleted.</param>
        public async Task DeleteAmenitie(int Id)
        {

            Amenities amenity = await _amenity.Amenities.FindAsync(Id);

            _amenity.Entry(amenity).State = EntityState.Deleted;

            await _amenity.SaveChangesAsync();
        }


        /// <summary>
        /// Retrieves a list of all Amenities from the database and returns them as a List of AmenityDTO objects.
        /// </summary>
        /// <returns>A List of AmenityDTO objects representing all available Amenities.</returns>
        public async Task<List<AmenityDTO>> GetAll()
        {
            return await _amenity.Amenities.Select(a => new AmenityDTO
            {
                Id = a.Id,
                Name = a.Name,
            }).ToListAsync();

            //var amenities = await _amenity.Amenities.ToListAsync();

            //return amenities;
        }


        /// <summary>
        /// Retrieves a specific Amenity from the database based on the provided ID and returns it as an AmenityDTO object.
        /// </summary>
        /// <param name="Id">The ID of the Amenity to retrieve.</param>
        /// <returns>An AmenityDTO object representing the requested Amenity; null if not found.</returns>

        public async Task<AmenityDTO> GetAmenitiesById(int Id)
        {
            var amenity = await _amenity.Amenities.Select(a => new AmenityDTO
            {
                Id = a.Id,
                Name = a.Name,
            }).FirstOrDefaultAsync(x => x.Id == Id);

            return amenity;
            //var amenity = await _amenity.Amenities.FindAsync(Id);
            //return amenity;
        }

        /// <summary>
        /// Updates an existing Amenity in the database based on the provided ID and Amenities object.
        /// Returns the updated Amenity if found; otherwise, returns null.
        /// </summary>
        /// <param name="Id">The ID of the Amenity to update.</param>
        /// <param name="amenities">The updated Amenities object containing new data.</param>
        /// <returns>The updated Amenity; null if the Amenity with the given ID does not exist.</returns>

        public async Task<Amenities> UpdateAmenitie(int Id, Amenities amenities)
        {


            var amenityValue = await _amenity.Amenities.FindAsync(Id);

            if (amenityValue != null)
            {
                amenityValue.Name = amenities.Name;

                await _amenity.SaveChangesAsync();
            }
            return amenityValue;

            //AmenityDTO amenityDTO = new AmenityDTO
            //{
            //    Id = amenities.Id,
            //    Name = amenities.Name,
            //};
            //_amenity.Entry(amenities).State = EntityState.Modified;
            //await _amenity.SaveChangesAsync();
            //return amenityDTO;
        }
    }
}
