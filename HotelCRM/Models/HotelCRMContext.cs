using Microsoft.EntityFrameworkCore;

namespace HotelCRM.Models
{
  public class HotelCRMContext : DbContext
  {
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<GuestRoom> GuestRoom { get; set; }
    public DbSet<RoomProperty> RoomProperty { get; set; }

    public HotelCRMContext(DbContextOptions options) : base(options) { }
  }
}