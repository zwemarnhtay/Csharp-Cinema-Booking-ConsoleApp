using CinemaBookingConsoleApp.Models;
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
                Console.WriteLine($"{movie.Id} - {movie.Title}");
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

        public void GetShowTimes(int movieId)
        {
            Console.WriteLine();
            List<Showtime> showtimes = _context.Showtimes.Where(x => x.MovieId == movieId).ToList();
            foreach(Showtime showtime in showtimes)
            {
                Console.WriteLine($"showtime : {showtime.Time}");
            }
        }
    }
}
