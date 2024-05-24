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

        public string GetAvaliableSeats(int showtimeId)
        {
            string strRow = string.Empty;
            string strCol = string.Empty;
            SeatDTO data = new SeatDTO();

            List<Booking> bookings = _context.Bookings.Where(x => x.ShowtimeId == showtimeId).ToList();

            if(data.Seats.Count() > 10)
            {
                List<string> uniqueRows = new List<string>();
                foreach (Seat seat in data.Seats)
                {
                    string row = seat.Row.ToString();
                    if (!uniqueRows.Contains(row))
                    {
                        uniqueRows.Add(row);
                    }
                }

                Console.Write("Row No : ");
                foreach (string row in uniqueRows)
                {
                    if (bookings.Any())
                    {
                        foreach(Booking booking in bookings)
                        {
                            if (!booking.SeatNo[0].Equals(row))
                            {
                                Console.Write($"{row} ");
                            }
                        }
                    }
                    else
                    {
                        Console.Write($"{row} ");
                    }
                }
                Console.Write("\n Enter Row No. :");
                strRow = Console.ReadLine().Trim().ToUpper();

                Console.Write("\n Column No : ");
                foreach (Seat seat in data.Seats)
                {
                    if (seat.Row.ToString() == strRow)
                    {
                        if (bookings.Any())
                        {
                            string seatNo = String.Concat(seat.Row, seat.No);
                            bool isExist = bookings.Any(b => b.SeatNo.Equals(seatNo));
                            if (!isExist)
                            {
                                Console.Write($"{seat.No} ");
                            }
                        }
                        else
                        {
                            Console.Write($"{seat.No} ");
                        }
                    }
                }
                Console.Write("\n Enter column No :");
                strCol = Console.ReadLine();
            }
            else
            {
                foreach (Seat seat in data.Seats)
                {
                    if (bookings.Any())
                    {
                        foreach (Booking booking in bookings)
                        {
                            string seatNo = String.Concat(seat.Row, seat.No);
                            if (!booking.SeatNo.Equals(seatNo))
                            {
                                Console.WriteLine($"SeatNo : {seat.Row}{seat.No}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"SeatNo : {seat.Row}{seat.No}");
                    }
                }
            }
            string No = String.Concat(strRow, strCol);
            return No;
        }
    }
}
