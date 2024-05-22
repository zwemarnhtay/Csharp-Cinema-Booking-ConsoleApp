using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp.Models
{
    [Table("Tbl_Movie")]
    public class Movie
    {
        [Key]
        [Column("MovieId")]
        public int Id { get; set; }
        [Column("MovieTitle")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
    }
}
