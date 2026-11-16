// Startpunkt för Hotel Grandioso.
// Här kopplar du ihop databasen och menyn.

// TODO: Skapa databasen med EF Core (se Data/README.md)

// TODO: Starta menyn (Boka rum, Avboka, Visa bokningar, Visa lediga rum, Avsluta)


bool hotel = true;

while (hotel)
{
    Console.WriteLine("=== Hotel Grandioso ===");
    Console.WriteLine("1. Boka rum");
    Console.WriteLine("2. Avboka");
    Console.WriteLine("3. Visa bokningar");
    Console.WriteLine("4. Visa lediga rum");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj ett alternativ: ");
    string? hotelChoice = Console.ReadLine();
    
    switch (hotelChoice)
    {
        case "1":
            Console.WriteLine("1. Boka rum");
            break;
        case "2":
            Console.WriteLine("1. Boka rum");
            break;
        case "3":
            Console.WriteLine("1. Boka rum");
            break;
        case "4":
            Console.WriteLine("1. Boka rum");
            break;
        case "5":
            Console.WriteLine("5. Avsluta");
            hotel = false;
            break;
            default:
                Console.WriteLine("Ogiltligt val");
                break;
    }
}
