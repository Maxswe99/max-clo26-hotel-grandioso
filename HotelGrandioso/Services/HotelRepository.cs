namespace HotelGrandioso.Services;

using HotelGrandioso.Data;
using HotelGrandioso.Models;
using Microsoft.EntityFrameworkCore;


public class HotelRepository
{
    private HotelContext Context;

    public HotelRepository(HotelContext context)
    {
        Context = context;
    }
    
    public List<Room> GetAllRooms()
    {
        return Context.Rooms
            .Include("RoomType")
            .ToList();
    }

    public List<Booking> GetAllBookings()
    {
        return Context.Bookings
            .Include("Guest")
            .Include("Room")
            .ToList();
    }
    
    public void AddBooking(Booking booking)
    {
        Context.Bookings.Add(booking);
        Context.SaveChanges();
    }
    
    public void DeleteBooking(int bookingId)
    {
        var booking = Context.Bookings.Find(bookingId);

        if (booking != null)
        {
            Context.Bookings.Remove(booking); 
            Context.SaveChanges();
        }
    }

    public int CalculateTotalPrice(Booking booking)
    {
        var nights = (booking.CheckOut - booking.CheckIn).Days;
        return nights *= booking.Room.PricePerNight;
    }
}
