using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaBookingConsoleApp.Models;

namespace CinemaBookingConsoleApp.Services
{
    internal class SeatService
    {
        private readonly DBContext _context;

        public SeatService()
        {
            _context = new DBContext();
        }

        public void GetAvaliableSeats(int showtimeId)
        {
            SeatDTO data = new SeatDTO();

            List<Booking> bookings = _context.Bookings.Where(x => x.ShowtimeId == showtimeId).ToList();

            foreach (Seat seat in data.Seats)
            {
                if (bookings.Any())
                {
                    foreach (Booking booking in bookings)
                    {
                        if (booking.SeatNo != $"{seat.Row}{seat.No}")
                        {
                            Console.WriteLine($"SeatNo : {seat.Row}{seat.No}");
                        }
                    }
                    break;
                }
                Console.WriteLine($"SeatNo : {seat.Row}{seat.No}");
            }
        }
    }
}
