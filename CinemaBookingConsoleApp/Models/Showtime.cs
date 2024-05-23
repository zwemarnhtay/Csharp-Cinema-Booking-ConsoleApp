using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp.Models
{
    [Table("Tbl_Showtime")]
    public class Showtime
    {
        [Column("ShowtimeId")]
        public int Id { get; set; }
        public int MovieId { get; set; }
        [Column("Showtime")]
        public DateTime Time { get; set; }
        //public SeatDTO Seats { get; set; }
    }
}
 