using Microsoft.EntityFrameworkCore;

namespace HotelCRM.Models
{
  public class HotelCRMContext : DbContext
  {
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<GuestRoom> GuestRooms { get; set; }
    public DbSet<GuestProperty> GuestProperties { get; set; }

    public HotelCRMContext(DbContextOptions options) : base(options) { }
  }
}