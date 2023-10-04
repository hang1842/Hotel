using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Hotel.Models
{
    public class CheckIn
    {
        [Key]
        public int CheckId { get; set; }

        [Required,NotNull]
        public int guestID { get; set; }
        [ForeignKey("guestID")]
        public Guest? guest { get; set; }

        [Required,NotNull]
        public int roomID { get; set; }
        [ForeignKey("roomID")]
        public Room? room { get; set; }

        [Required,DataType(DataType.DateTime),NotNull]
        public DateTime CheckInDate { get; set; } = DateTime.Now;

        [Required, DataType(DataType.DateTime),AllowNull]
        public DateTime CheckOutDate { get; set; }

        [Required,NotNull]
        public decimal pre_payment_amount { get; set; }

        [Required,NotNull,StringLength(15)]
        public string pre_payment_method { get; set; } = "Credit Card";//Credit Card,Debit Card
    }

}
