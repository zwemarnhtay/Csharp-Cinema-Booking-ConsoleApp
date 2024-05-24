using CinemaBookingConsoleApp.Services;

MovieService Movie = new MovieService();
SeatService Seat = new SeatService();
BookingService Booking = new BookingService();

while (true)
{
    Console.WriteLine("\n --WELCOME TO AMENIC--");
    Console.WriteLine("1 - Show avaliable movies list");
    Console.WriteLine("2 - Exit");
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

            Console.Write("\n Do you want to check avaliable seats? (yes/no) :");
            YN = Console.ReadLine().Trim().ToLower();

            if(YN != "yes" || YN != "y")
            {
                string seatNo = Seat.GetAvaliableSeats(showtimeId);

                Console.Write($"\n seat No. : {seatNo}");
                Booking.bookTicket(movieNo,showtimeId, seatNo);
            }
        }
        else if(YN == "no" || YN == "n")
        {
            Console.WriteLine("\n <===========>");
        }
        else
        {
            Console.WriteLine("\n invalid input!");
        }

    }
    else if (choice == 2)
    {
        Console.WriteLine("Thank you for your time!");
        break;
    }
}
