using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Staff
    {
        [Key]
        public int staff_ID { get; set; }

        [StringLength(20), NotNull]
        public string staff_FName { get; set; } = default!;

        [StringLength(20), NotNull]
        public string staff_LName { get; set; }=default!;

        [Required, StringLength(10), NotNull]
        public string staff_Gender { get; set; } = default!;

        [Required,NotNull]
        public int de_ID { get; set; }

        [ForeignKey("de_ID"), AllowNull]
        public Department department { get; set; }

        [Required, StringLength(20), NotNull]
        public string staff_Position { get; set; }= default!;//HouseKeeper,Manager,Administor,Reception

        [Required, StringLength(30), NotNull]
        public string staff_Email { get; set; } = default!;

        [Required, StringLength(15), NotNull]
        public string staff_Password { get; set; } = default!;

        [Required,StringLength(20), AllowNull]
        public string staff_Phone { get; set; }

        [Required, StringLength(50), NotNull]
        public string staff_Address { get; set; } = default!;

        //relation
        public List<RoomService>? roomService { get; set; }

    }
}
