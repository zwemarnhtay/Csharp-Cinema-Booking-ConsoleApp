using CinemaBookingConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp.Services
{
    internal class MovieService
    {
        private readonly DBContext _context;

        public MovieService()
        {
            _context = new DBContext();
        }

        public void GetMoviesList()
        {
            Console.WriteLine();
            var movies = _context.Movies.ToList();
            foreach (Movie movie in movies)
            {
                Console.WriteLine($"\t {movie.Id} - {movie.Title}");
            }
        }

        public bool DetailSelected(int No)
        {
            Console.WriteLine();
            var movie = _context.Movies.FirstOrDefault(x => x.Id == No);
            if (movie != null) 
            {
                Console.WriteLine($"No. - {movie.Id}");
                Console.WriteLine($"Title - {movie.Title}");
                Console.WriteLine($"Description. - {movie.Description}");
                Console.WriteLine($"Genre. - {movie.Genre}");
                Console.WriteLine($"Rating. - {movie.Rating}");
                Console.WriteLine($"Duration. - {movie.Duration}");
                return true;
            } else 
            {
                Console.WriteLine("There is no such Movie No.");
                return false;
            }
        }

        public int GetShowTimes(int movieId)
        {
            Console.WriteLine();
            List<Showtime> showtimes = _context.Showtimes.Where(x => x.MovieId == movieId).ToList();

            int counter = 1;
            int[,] dir = new int[showtimes.Count,2];

            int showtimeId = -1;

            if (showtimes.Any())
            {
                foreach (Showtime showtime in showtimes)
                {
                    dir[counter - 1, 0] = counter;
                    dir[counter - 1, 1] = showtime.Id;
                    Console.WriteLine($"{counter} showtime : {showtime.Time}");
                    counter++;
                }

                Console.Write("choose showtime :");

                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.Write("Invalid input, enter number : ");
                }

                for (int i = 0; i < dir.GetLength(0); i++)
                {
                    if (dir[i, 0] == num)
                    {
                        showtimeId = dir[i, 1]; break;
                    }
                }
            }
            return showtimeId;
        }
    }
}
