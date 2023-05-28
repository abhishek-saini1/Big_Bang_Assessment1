using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Hotel
    {
        [Key]
        public int HId { get; set; }
        public string? HName { get; set; }
        public string? HLocation { get; set; }
        public string? HDescription { get; set; }
        public string? HAmenities { get; set; }

        public decimal HPrice { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
