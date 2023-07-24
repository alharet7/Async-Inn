using Async_Inn.Data;
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
        public async Task<Amenities> Create(Amenities amenities)
        {

            _amenity.Amenities.Add(amenities);

            await _amenity.SaveChangesAsync();

            return amenities;
        }

        public async Task DeleteAmenitie(int Id)
        {

            Amenities amenity = await GetAmenitiesById(Id);

            _amenity.Entry<Amenities>(amenity).State = EntityState.Deleted;

            await _amenity.SaveChangesAsync();
        }

        public async Task<List<Amenities>> GetAll()
        {
            var amenities = await _amenity.Amenities.ToListAsync();

            return amenities;
        }

        public async Task<Amenities> GetAmenitiesById(int Id)
        {
            var amenity = await _amenity.Amenities.FindAsync(Id);
            return amenity;
        }

        public async Task<Amenities> UpdateAmenitie(int Id, Amenities amenities)
        {
            var amenityValue = await _amenity.Amenities.FindAsync(Id);

            if (amenityValue != null)
            {
                amenityValue.Name = amenities.Name;

                await _amenity.SaveChangesAsync();
            }
            return amenityValue;
        }
    }
}
