using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models
{
    public class HotelRoomDbContext : DbContext
    {
        public HotelRoomDbContext(DbContextOptions<HotelRoomDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hotel>()
                .HasMany(hotel => hotel.Rooms)
                .WithOne(room => room.Hotel)
                .HasForeignKey(room => room.HotelId);
        }
    }
}
