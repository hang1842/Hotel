using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Payment
    {
        [Key] 
        public int payment_ID { get; set; }

        [Required,NotNull]
        public int guestID { get; set; }

        [ForeignKey("guestID"),AllowNull]
        public Guest guest { get; set; }

        [Required,NotNull]
        public int Accommodation_days { get; set; } = default!;

        [Required,NotNull]
        public decimal Consumption_Charges { get; set; } = default!;

        [Required, DataType(DataType.DateTime),NotNull]
        public DateTime create_date { get; set; }

        [Required, NotNull]
        public decimal payment_Rate { get; set; }

        [Required, NotNull]
        public decimal payment_Amount { get; set; }

        [Required, StringLength(15), NotNull]
        public string pay_method { get; set; } = default!;//Pending,Cash,Credit Card,Debit Card,Online,EFTPOS,Vouchers

        [Required, DataType(DataType.DateTime), AllowNull]
        public DateTime paid_date { get; set; } 
    }
}
