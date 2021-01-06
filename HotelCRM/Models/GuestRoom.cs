namespace HotelCRM.Models
{
  public class GuestRoom
  {
    public int GuestRoomId { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public Guest Guest { get; set; }
    public Room Room { get; set; }
  }
}