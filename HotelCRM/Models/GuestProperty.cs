namespace HotelCRM.Models
{
  public class GuestProperty
  {
    public int GuestPropertyId { get; set; }
    public int GuestId { get; set; }
    public int PropertyId { get; set; }
    public Guest Guest { get; set; }
    public Property Property { get; set; }
  }
}