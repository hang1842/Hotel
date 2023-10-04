using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Member
    {
        [Key] 
        public int MemID { get; set; }

        [Required, StringLength(20), NotNull]
        public string FName { get; set; } = default!;

        [Required,StringLength(20), NotNull]
        public string LName { get; set; }=default!;

        [Required, StringLength(20), NotNull]
        public string Organization { get; set; } = "Individual";

        [Required,StringLength(10), NotNull]
        public string Gender { get; set; }

        [Required,StringLength(10), NotNull]
        public string Category { get; set; }

        [Required, StringLength(30), NotNull]
        public string Email { get; set; } = default!;

        [Required, StringLength(15), NotNull]
        public string Password { get; set; } = default!;

        [Required,StringLength(10), NotNull]
        public string Phone { get; set; }

        [Required,StringLength(50), NotNull]
        public string Address { get; set; }
       

        //relation
        public List<Booking>? bookings { get; set; }    
    }
}
