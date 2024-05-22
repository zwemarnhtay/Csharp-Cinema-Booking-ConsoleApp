using CinemaBookingConsoleApp.Services;

var Movie = new MovieService();

while (true)
{
    Console.WriteLine("WELCOME TO AMENIC");
    Console.WriteLine("1 - Show avaliable movies list");
    Console.WriteLine("2 - Exit");
    Console.Write("Your choice :");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Movie.GetMoviesList();

        bool isExist;
        do
        {
            Console.Write("Enter Movie No. :");
            int movieNo = int.Parse(Console.ReadLine());
            isExist = Movie.DetailSelected(movieNo);
        } while (isExist == false);
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
