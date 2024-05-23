using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp.Models
{
    [Table("Tbl_Booking")]
    internal class Booking
    {
        [Key]
        [Column("BookingId")]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ShowtimeId { get; set; }
        public string SeatNo { get; set; } //Row + No from Seat model
        public bool IsBooked { get; set; }
        public string BookedBy { get; set; }

    }
}
