using HotelGrandioso.Models;

namespace HotelGrandioso.Data;

public class DbSeeder
{
    public static void Seed(HotelContext context)
    {
        if (!context.RoomTypes.Any())
        {
            context.RoomTypes.Add(new RoomType
            {
                Name = "Standard",
                Description = "Standardrum"
            });
            context.SaveChanges();
            
            context.RoomTypes.Add(new RoomType
            {
                Name = "Lyxsvit",
                Description = "Lyxsvitrum"
            });
            context.SaveChanges();
            
            context.RoomTypes.Add(new RoomType
            {
                Name = "Bröllopsvit",
                Description = "Bröllopsvitrum"
            });
            context.SaveChanges();
        }

        if (!context.Rooms.Any())
        {
            for (int roomNumber = 101; roomNumber <= 105; roomNumber++)
            {
                context.Rooms.Add(new Room
                {
                    RoomTypeId = 1,
                    RoomNumber = roomNumber,
                    Floor = 1,
                    SizeM2 = 80,
                    PricePerNight = 800
                });
                context.SaveChanges();
            }

            for (int roomNumber = 201; roomNumber <= 205; roomNumber++)
            {
                context.Rooms.Add(new Room
                {
                    RoomTypeId = 1,
                    RoomNumber = roomNumber,
                    Floor = 2,
                    SizeM2 = 100,
                    PricePerNight = 1000
                });
                context.SaveChanges();
            }

            for (int roomNumber = 301; roomNumber <= 303; roomNumber++)
            {
                context.Rooms.Add(new Room
                {
                    RoomTypeId = 1,
                    RoomNumber = roomNumber,
                    Floor = 3,
                    SizeM2 = 120,
                    PricePerNight = 1200
                });
                context.SaveChanges();
            }

            context.Rooms.Add(new Room
            {
                RoomTypeId = 2,
                RoomNumber = 304,
                Floor = 3,
                SizeM2 = 180,
                PricePerNight = 2800
            });
            context.SaveChanges();

            context.Rooms.Add(new Room
            {
                RoomTypeId = 3,
                RoomNumber = 305,
                Floor = 3,
                SizeM2 = 220,
                PricePerNight = 3500
            });
            context.SaveChanges();
        }
    }
}