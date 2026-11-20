namespace HotelGrandioso.Models;

public class Booking
{
    public int GuestId { get; set; }
    public int BookingId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int RoomId { get; set; }

    public Booking(int guestId, int bookingId, DateTime checkIn, DateTime checkOut, int roomId)
    {
        GuestId = guestId;
        BookingId = bookingId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        RoomId = roomId;
    }
    
    public Booking()
    {
        
    }
}