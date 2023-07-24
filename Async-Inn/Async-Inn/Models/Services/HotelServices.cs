using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class HotelServices : IHotel
    {
        private readonly AsyncInnDbContext _hotel;

        public HotelServices(AsyncInnDbContext hotel)
        {
            _hotel = hotel;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _hotel.Hotels.Add(hotel);
            await _hotel.SaveChangesAsync();

            return hotel;
        }

        public async Task Delete(int Id)
        {
            Hotel hotel = await GetHotelById(Id);
            _hotel.Entry<Hotel>(hotel).State = EntityState.Deleted;

            await _hotel.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetHotel()
        {
            var hotel = await _hotel.Hotels.ToListAsync();

            return hotel;
        }

        public async Task<Hotel> GetHotelById(int Id)
        {
            Hotel hotel = await _hotel.Hotels.FindAsync(Id);

            return hotel;
        }

        public async Task<Hotel> UpDateHotel(int Id, Hotel hotel)
        {
            var hotelValue = await _hotel.Hotels.FindAsync(Id);
            if (hotelValue != null)
            {
                hotelValue.Name = hotel.Name;
                hotelValue.State = hotel.State;
                hotelValue.Phone = hotel.Phone;
                hotelValue.StreetAddress = hotel.StreetAddress;
                hotelValue.City = hotel.City;
                hotelValue.Country = hotel.Country;

                await _hotel.SaveChangesAsync();
            }
            return hotelValue;

        }
    }
}
