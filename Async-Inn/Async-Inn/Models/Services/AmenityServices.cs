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

        public async Task DeleteAmenitie(int Id)
        {

            Amenities amenity = await _amenity.Amenities.FindAsync(Id);

            _amenity.Entry(amenity).State = EntityState.Deleted;

            await _amenity.SaveChangesAsync();
        }

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
