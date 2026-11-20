namespace HotelGrandioso.Models;

public class RoomType
{
    public int RoomTypeId { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<Room> Rooms { get; set; } = new List<Room>();

    public RoomType(int roomTypeId, string name, string description, List<Room> rooms)
    {
        RoomTypeId = roomTypeId;
        Name = name;
        Description = description;
        Rooms = rooms;
    }

    public RoomType()
    {
        
    }
}