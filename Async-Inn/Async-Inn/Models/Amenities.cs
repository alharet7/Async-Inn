namespace Async_Inn.Models
{
    public class Amenities
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Nav Prop
        public List<RoomAmenities> RoomAmenities { get; set; }

    }
}
