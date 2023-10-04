using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class BusinessService
    {
        [Key]
        public int BS_ID { get; set; }

        [Required, NotNull, StringLength(20)]
        public string BS_Name { get; set; } = default!;
        [Required,NotNull]
        public decimal BS_Rate { get; set; }
        [Required,NotNull]
        public decimal BS_Price { get; set; }

        [AllowNull,StringLength(200)]
        public  string BS_Description { get; set; }

        //relation
        public  List<Consumption>? consumption { get; set; }
    }
}
