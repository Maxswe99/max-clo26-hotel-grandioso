namespace HotelGrandioso.Models;

public class Room
{
    public int RoomId { get; set; }
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; } = null!;
    public int RoomNumber { get; set; }
    public int Floor { get; set; }
    public int SizeM2 { get; set; }
    public int PricePerNight { get; set; }
    public List<Booking> Bookings { get; set; } = new();
}

