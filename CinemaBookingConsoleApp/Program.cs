using CinemaBookingConsoleApp.Services;

var Movie = new MovieService();

while (true)
{
    Console.WriteLine("\n --WELCOME TO AMENIC--");
    Console.WriteLine("1 - Show avaliable movies list");
    Console.WriteLine("2 - Exit");
    Console.Write("Your choice :");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Movie.GetMoviesList();

        int movieNo;
        bool isExist;
        do
        {
            Console.Write("Enter Movie No. :");
            movieNo = int.Parse(Console.ReadLine());
            isExist = Movie.DetailSelected(movieNo);
        } while (isExist == false);

        Console.WriteLine("\n Do you want to see showtimes? (yes/no)");
        string YN = Console.ReadLine().Trim().ToLower();

        if(YN == "yes" || YN == "y")
        {
            Movie.GetShowTimes(movieNo);
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
    else
    {
        Console.WriteLine("Invalid choice");
    }
}
