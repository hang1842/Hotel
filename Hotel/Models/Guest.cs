using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }

        [Required, StringLength(20), NotNull]
        public string FName { get; set; } = default!;

        [Required,StringLength(20), NotNull]
        public string LName { get; set; }= default!;

        [Required, StringLength(10), NotNull]
        public string ID { get; set; } = default!;

        [Required,StringLength(10), NotNull]
        public string Gender { get; set; }=default!;

        [Required, StringLength(10), NotNull]
        public string Phone { get; set; } = default!;

        [Required, StringLength(30), NotNull]
        public string Email { get; set; } = default!;

        [Required, StringLength(50), NotNull]
        public string Organization { get; set; } = "Individual";

        [Required,StringLength(30), AllowNull]
        public string Hometown { get; set; }

        [Required,StringLength(100), AllowNull]
        public string? Preference { get; set; }



        //relation
        public List<Consumption>? consumptions { get; set; }
        public List<CheckIn>? checkins { get; set; }
    }
}
