namespace Async_Inn.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }


        //Nav Prop

        public List<HotelRoom>? hotelroom { get; set; }
        public List<RoomAmenities>? RoomAmenities { get; set; }
    }
    // public enum Layout
}
