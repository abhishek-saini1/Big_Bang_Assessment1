using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Room
    {
        [Key]
        public int RId { get; set; }
        public int RoomNumber { get; set; }

        public bool RoomAvailable { get; set; }
        public string? RoomType { get; set; }
        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
