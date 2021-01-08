using System.Collections.Generic;

namespace HotelCRM.Models
{
  public class Room
  {
    public Room()
    {
      this.Guests = new HashSet<GuestRoom>();
      this.Properties = new HashSet<RoomProperty>();
    }

    public int RoomId { get; set; }
    public string RoomType { get; set; }
    public int RoomNumber { get; set; }
    public int MaxOccupancy { get; set; }
    public int PropertyId { get; set; }

    public ICollection<GuestRoom> Guests { get; set; }
    public ICollection<RoomProperty> Properties { get; set; }
  }
}