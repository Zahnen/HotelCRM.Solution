using System.Collections.Generic;

namespace HotelCRM.Models
{
  public class Guest
    {
      public Guest()
      {
        this.Rooms = new HashSet<GuestRoom>();
      }

      public int GuestId { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
      public string Hometown { get; set; }
      public int LifetimeNights { get; set; }
      public string VIPTier{ get; set; }
      public int RoomId { get; set; }

      public virtual ICollection<GuestRoom> Rooms { get; set; }
    }
}