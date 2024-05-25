using CinemaBookingConsoleApp.Services;

MovieService Movie = new MovieService();
SeatService Seat = new SeatService();
BookingService Booking = new BookingService();

while (true)
{
    Console.Title = "Cinema_Booking";
    Console.WriteLine("\n --WELCOME TO AMENIC--");
    Console.WriteLine("\t 1 - Show avaliable movies list");
    Console.WriteLine("\t 2 - Exit");
    Console.Write("Your choice :");

    if(!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid Input, enter 1 or 2!");
    }

    if (choice == 1)
    {
        Movie.GetMoviesList();

        int movieNo;
        bool isExist;
        string YN;
        do
        {
            Console.Write("Enter Movie No. :");
            movieNo = int.Parse(Console.ReadLine());
            isExist = Movie.DetailSelected(movieNo);
        } while (isExist == false);

        Console.Write("\n Do you want to see showtimes? (yes/no) :");
        YN = Console.ReadLine().Trim().ToLower();

        if(YN == "yes" || YN == "y")
        {
            int showtimeId = Movie.GetShowTimes(movieNo);

            if(showtimeId != -1)
            {
                Console.Write("\n Do you want to check avaliable seats? (yes/no) :");
                YN = Console.ReadLine().Trim().ToLower();

                if (YN == "yes" || YN == "y")
                {
                    string seatNo = Seat.GetAvaliableSeats(showtimeId);

                    Console.Write($"\n seat No. : {seatNo}");
                    Booking.bookTicket(movieNo, showtimeId, seatNo);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There are no avaliable seats");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else if(YN == "no" || YN == "n")
        {
            Console.WriteLine("\n <===========>");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n invalid input!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else if (choice == 2)
    {
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("\n \t Thank you for your time! \n");
        Console.ForegroundColor = ConsoleColor.White;
        break;
    }
}
