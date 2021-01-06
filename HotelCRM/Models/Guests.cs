using System.Collections.Generic;

namespace HotelCRM.Models
{
  public class Guest
    {
      public Guest()
      {
        this.Rooms = new HashSet<GuestRoom>();
        this.Properties = new HashSet<GuestProperty>();
      }

      public int GuestId { get; set; }
      public int PropertyId{ get; set; }
      public int RoomId { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
      public string Hometown { get; set; }
      public int LifetimeNights { get; set; }
      public string VIPTier{ get; set; }
      public virtual ICollection<GuestRoom> Rooms { get; set; }
      public virtual ICollection<GuestProperty> Properties { get; set; }
    }
}