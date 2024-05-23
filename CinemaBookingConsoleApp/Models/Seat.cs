using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp
{
    
    public class SeatDTO
    {
        public int ShowTimeId { get; set; } 
        public Seat[] Seats { get; set; }

        public SeatDTO()
        {
            Seats = new Seat[50];
            char[] row = { 'A', 'B', 'C', 'D', 'E' };

            int index = 0;
            foreach (char c in row)
            {
                for (int i = 1;  i <= 10; i++)
                {
                    var seat = new Seat()
                    {
                        Row = c,
                        No = i
                    };
                    Seats[index++] = seat;
                }
            }
        }
    }

    public class Seat
    {
        public char Row { get; set; }
        public int No { get; set; }
    }



}
