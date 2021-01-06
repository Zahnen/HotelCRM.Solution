using System.Collections.Generic;

namespace HotelCRM.Models
{
  public class Property
  {
    public Property()
    {
      this.Guests = new HashSet<GuestProperty>();
    }

    public int PropertyId { get; set; }
    public string Name { get; set; }
    public int Stars { get; set; }
    public int Age { get; set; }
    public string Neighborhood { get; set; }

    public ICollection<GuestProperty> Guests { get; set; }
  }
}