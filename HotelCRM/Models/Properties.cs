using System.Collections.Generic;

namespace HotelCRM.Models
{
  public class Property
  {
    public Property()
    {
      this.Rooms = new HashSet<RoomProperty>();
    }
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public int Stars { get; set; }
    public int YearBuilt { get; set; }
    public string City { get; set; }
    public ICollection<RoomProperty> Rooms { get; set; }
    
  }
}