using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        public int room_ID { get; set; }

        [Required, NotNull, StringLength(10)]
        public string room_number { get; set; } = default!;

        [Required, NotNull, StringLength(20)]
        public string room_Name { get; set; } = default!;

        [Required, NotNull,StringLength(15)]
        public string room_Type { get; set; } = "single";//'Single','Two bedrooms','Superior'       

        [Required, NotNull]
        public decimal room_Price { get; set; } = default!;

        [Required, NotNull]
        public decimal room_Rate { get; set; }=default!;

        [Required, NotNull, StringLength(20)]
        public string room_Status { get; set; } = "Vacant Clear";//'Reserve','Vacant Clean','Vacant Dirty','Occupied Clean','Occupied Service','Maintenance'

        [Required, NotNull, StringLength(200)]
        public string room_Description { get; set; } = default!;


        //relations
        public List<CheckIn>? checkIns { get; set; }
        public List<RoomService>? roomService { get; set; }
    }
}
