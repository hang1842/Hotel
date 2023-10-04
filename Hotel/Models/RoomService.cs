using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class RoomService
    {
        [Key] 
        public int ServiceId { get; set; }

        [Required,StringLength(15), NotNull]
        public string Type { get; set; } = "Clear";//"Clear","Service",and "Maintainece"

        [Required,NotNull]
        public int staffID { get; set; }

        [ForeignKey("staffID"),AllowNull]
        public Staff Staff { get; set; }

        [Required,NotNull]
        public int RoomID { get; set; }

        [ForeignKey("RoomID"), AllowNull]
        public Room Room { get; set; }

        [Required,StringLength(10), NotNull]
        public string Status { get; set; } = "Waitting";//Waitting, executing, completed
    }
}
