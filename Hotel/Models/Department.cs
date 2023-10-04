using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Models
{
    public class Department
    {
        [Key]
        public int de_ID { get; set; }

        [Required, NotNull, StringLength(30)]
        public string de_Name { get; set; } = default!;

        //relations
       public List<Staff>? staffs { get; set; }
    }
}
