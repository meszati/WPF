using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XY57LW_HFT_2021221.Models
{
    [Table("schools")]

    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SchID { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Headmaster { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
        public School()
        {
            Students = new HashSet<Student>();
        }

        public override string ToString()
        {
            return "Name: " + this.Name + " |Headmaster: " + this.Headmaster;
        }
    }
}
