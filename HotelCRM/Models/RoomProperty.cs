namespace HotelCRM.Models
{
  public class RoomProperty
  {
    public int RoomPropertyId { get; set; }
    public int RoomId { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
    public Room Room { get; set; }
  }
}