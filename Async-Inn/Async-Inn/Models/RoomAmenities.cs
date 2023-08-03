using Async_Inn.Models.Interfaces;

namespace Async_Inn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesId { get; set; }
        public int RoomID { get; set; }

        public Amenities? Amenities { get; set; }
        public Room? Room { get; set; }
    }
}
