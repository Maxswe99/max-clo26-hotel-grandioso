using Microsoft.EntityFrameworkCore;
using HotelGrandioso.Data;
using HotelGrandioso.Models;
using HotelGrandioso.Services;


using var context = new HotelContext();
context.Database.Migrate();
var repository = new HotelRepository(context);

DbSeeder.Seed(context);


// Any() betyder att kontrollen bara lägger till startdata om tabellen är tom

var rooms = repository.GetAllRooms();

bool hotel = true;

while (hotel)
{
    Console.WriteLine("=== Hotel Grandioso ===");
    Console.WriteLine("1. Boka rum");
    Console.WriteLine("2. Avboka");
    Console.WriteLine("3. Visa bokningar");
    Console.WriteLine("4. Visa alla rum");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj ett alternativ: ");
    string? hotelChoice = Console.ReadLine();
    
    switch (hotelChoice)
    {
        case "1":
        {
            Console.Write("Gästnamn: ");
            string? guestName = Console.ReadLine();

            var guest = new Guest
            {
                Name = guestName ?? ""
            };

            Console.Write("Incheckning (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime checkin))
            {
                Console.WriteLine("Ogiltigt datum.");
                break;
            }

            Console.Write("Utcheckning (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime checkout))
            {
                Console.WriteLine("Ogiltigt datum.");
                break;
            }

            if (checkout <= checkin)
            {
                Console.WriteLine("Utcheckning måste vara efter incheckning.");
                break;
            }

            Console.WriteLine("Välj rum:");

            int listNumber = 1;
            foreach (var room in rooms)
            {
                Console.WriteLine($"{listNumber}. Rum: {room.RoomNumber}, Typ: {room.RoomType.Name}, Storlek: {room.SizeM2} (m2), Kostnad: {room.PricePerNight} kr / natt.");
                listNumber++;
            }

            Console.Write("Val: ");
            string? roomChoice = Console.ReadLine();

            if (!int.TryParse(roomChoice, out int selectedChoice) || selectedChoice < 1 || selectedChoice > rooms.Count)
            {
                Console.WriteLine("Ogiltigt rums val.");
                break;
            }

            var selectedRoom = rooms[selectedChoice - 1];

            // själva bokningen
            var booking = new Booking
            {
                Guest = guest,
                Room = selectedRoom,
                CheckIn = checkin,
                CheckOut = checkout
            };

            repository.AddBooking(booking);

            Console.WriteLine("Bokningen är sparad.");
            Console.WriteLine($"Du har valt rum {selectedRoom.RoomNumber}");
            Console.WriteLine($"Typ: {selectedRoom.RoomType.Name}");
            Console.WriteLine($"Storlek: {selectedRoom.SizeM2} m²");
            Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight} kr");
            Console.WriteLine($"Totalt pris: {repository.CalculateTotalPrice(booking)} kr");

            Console.WriteLine("Tryck på enter för att gå tillbaka");
            Console.ReadLine();

            break;
        }
        case "2":
        {
            var bookings = repository.GetAllBookings();

            if (bookings.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns inga bokningar att avboka.");
                Console.WriteLine("Tryck enter för att gå tillbaka till menyn");
                Console.ReadLine();
                break;
            }
            
            Console.WriteLine();
            
            foreach (var reservation in bookings)
            {
                Console.WriteLine($"Boknings-ID: {reservation.BookingId}");
                Console.WriteLine($"Gäst: {reservation.Guest.Name}");
                Console.WriteLine($"Rum: {reservation.Room.RoomNumber}");
                Console.WriteLine();
            }

            Console.Write("Ange boknings-ID att avboka: ");

            if (!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.WriteLine("Ogiltigt boknings-ID.");
                break;
            }

            Booking? bookingToDelete = null;

            foreach (var booked in bookings)
            {
                if (booked.BookingId == bookingId)
                {
                    bookingToDelete = booked;
                    break;
                }
            }

            if (bookingToDelete == null)
            {
                Console.WriteLine("Bokningen hittades inte.");
                break;
            }

            repository.DeleteBooking(bookingId);
            Console.WriteLine("Bokningen har avbokats.");
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att gå tillbaka till menyn");
            Console.ReadLine();
            break;
        }
        case "3":
        {
            var bookings = repository.GetAllBookings();
            if (bookings.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns inga aktiva bokningar.");
                Console.WriteLine("Tryck enter för att gå tillbaka till menyn");
                Console.ReadLine();
                break;
            }

            Console.WriteLine();
            
            foreach (var showBooking in bookings)
            {
                Console.WriteLine($"Boknings-ID: {showBooking.BookingId}");
                Console.WriteLine($"Gäst: {showBooking.Guest.Name}");
                Console.WriteLine($"Rum: {showBooking.Room.RoomNumber}");
                Console.WriteLine($"Incheckning: {showBooking.CheckIn:yyyy-MM-dd}");
                Console.WriteLine($"Utcheckning: {showBooking.CheckOut:yyyy-MM-dd}");
                Console.WriteLine($"Pris: {repository.CalculateTotalPrice(showBooking)} kr");
                Console.WriteLine();
            }
            Console.WriteLine("Tryck enter för att gå tillbaka till menyn");
            Console.ReadLine();
            break;
        }
        case "4":
        {
            Console.WriteLine("Visar alla lediga rum:");

            foreach (var room in rooms)
            {
                Console.WriteLine(
                    $"Rum: {room.RoomNumber}, Typ: {room.RoomType.Name}, Storlek: {room.SizeM2} (m2), Kostnad: {room.PricePerNight} kr / natt.");
            }

            Console.WriteLine("Tryck på enter för att gå tillbaka");
            Console.ReadLine();
            break;
        }
        case "5":
        {
            hotel = false;
            break;
        }
        default:
        {
            Console.WriteLine("Ogiltigt val");
            break;
        }
    }
}
