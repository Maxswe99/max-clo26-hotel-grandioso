namespace HotelGrandioso.Models;

public class Guest
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    // skippar HairColor, HeightCm och religion då det är irrelevant #gdpr
    public List<Booking> Bookings { get; set; } = new List<Booking>();

    public Guest()
    {
        
    }
}