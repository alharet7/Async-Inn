

using System.ComponentModel.DataAnnotations.Schema;

namespace Async_Inn.Models
{
    public class HotelRoom
    {

        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        // Nav Prop

        public Hotel? hotel { get; set; }


        public Room? room { get; set; }

    }
}
