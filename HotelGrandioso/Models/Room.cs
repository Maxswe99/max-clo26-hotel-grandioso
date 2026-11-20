namespace HotelGrandioso.Models;

public class Room
{
    public int RoomId { get; set; }
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public int RoomNumber { get; set; }
    public int Floor { get; set; }
    public int SizeM2 { get; set; }
    public int PricePerNight { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();

    public Room(int roomTypeId, RoomType roomType, int roomNumber, int floor, int sizeM2, int pricePerNight)
    {
        RoomTypeId = roomTypeId;
        RoomType = roomType;
        RoomNumber = roomNumber;
        Floor = floor;
        SizeM2 = sizeM2;
        PricePerNight = pricePerNight;
    }

    public Room()
    {
        
    }
}

