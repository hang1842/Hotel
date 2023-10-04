using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Hotel.Models
{
    public class Booking
    {
        [Key]
        public int bookID { get; set; }

        [Required, NotNull]
        public string ReferenceNumber { get; set; } = default!;

        [Required, NotNull]
        public int MemID { get; set; }

        [ForeignKey("MemID"), AllowNull]
        public Member member { get; set; }

        [Required, NotNull, StringLength(15)]
        public string room_Type1 { get; set; } = "Single";//Single,Two bedrooms,Superior

        [Required, NotNull]
        public int room_Quantity1 { get; set; } = 1;

        [AllowNull, StringLength(15)]
        public string room_Type2 { get; set; }

        [AllowNull]
        public int room_Quantity2 { get; set; }

        [AllowNull, StringLength(15)]
        public string room_Type3 { get; set; }

        [AllowNull]
        public int room_Quantity3 { get; set; }

        [Required,DataType(DataType.DateTime),NotNull]
        public DateTime CheckInTime { get; set; }

        [Required,DataType(DataType.DateTime),NotNull]
        public DateTime CheckOutTime { get; set; }

        [Required, AllowNull, Range(0, 3)]
        public int CarPark { get; set; } = 0;
    }
}
