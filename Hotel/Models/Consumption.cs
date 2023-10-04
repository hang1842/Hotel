using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Consumption
    {
        [Key]
        public int con_ID { get; set; }
        [Required,NotNull]
        public int guestID { get; set; }

        [ForeignKey("guestID"), AllowNull]
        public Guest guest { get; set; }

        [Required,NotNull]
        public int BS_ID { get; set; }

        [ForeignKey("BS_ID"), AllowNull]
        public BusinessService? service { get; set; }

        [Required, NotNull, Range(1, 5)]
        public int Service_Quantity { get; set; } = 1;

        [Required,NotNull]
        public decimal con_Amount { get; set; }
    }
}
