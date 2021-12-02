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
    [Table("students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StudentID { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [NotMapped]
        public string MothersName { get; set; }

        [Required]
        public string City { get; set; }

        [ForeignKey(nameof(School))]
        public int SchoolID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual School School { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Measurement Netfit { get; set; }

        [ForeignKey(nameof(Measurement))]
        public int NetfitID { get; set; }

        public override string ToString()
        {
            return "Name: " + this.Name + " |City: " + this.City;
        }
    }
}
