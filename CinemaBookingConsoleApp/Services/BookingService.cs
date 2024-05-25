using CinemaBookingConsoleApp.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp.Services
{
    internal class BookingService
    {
        private readonly DBContext _context;

        public BookingService()
        {
            _context = new DBContext(); 
        }

        public void bookTicket(int movieId, int showtimeId, string seatNo)
        {
            Showtime showtime = _context.Showtimes.FirstOrDefault(x => x.Id == showtimeId)!;
            
            Console.WriteLine("\n ===> Ticket <===");
            Console.WriteLine($"movieNo. : {movieId}");
            Console.WriteLine($"Showtime : {showtime.Time}");
            Console.WriteLine($"SeatNo.  : {seatNo}");

            string bookedBy = string.Empty;

            do
            {
                Console.Write("Customer Name :");
                bookedBy = Console.ReadLine().Trim();
            }while(bookedBy.IsNullOrEmpty());

            Booking booking = new Booking()
            {
                MovieId = movieId,
                ShowtimeId = showtimeId,
                SeatNo = seatNo,
                IsBooked = true,
                BookedBy = bookedBy
            };

            _context.Bookings.Add(booking);
            int result = _context.SaveChanges();

            string msg = result > 0 ? "booking success" : "failed";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n \t {msg} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
