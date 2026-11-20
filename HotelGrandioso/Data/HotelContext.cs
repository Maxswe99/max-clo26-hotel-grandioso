namespace HotelGrandioso.Data;

using Microsoft.EntityFrameworkCore;
using HotelGrandioso.Models;

public class HotelContext : DbContext
{
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Booking> Bookings => Set<Booking>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=HotelGrandioso.db");
    
    public HotelContext()
    {
        
    }
}