using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY57LW_HFT_2021221.Models
{
    [Table("students")]
    class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StudentID { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public string MothersName { get; set; }

        [Required]
        public string City { get; set; }

        [ForeignKey(nameof(School))]
        public int SchoolOM { get; set; }

        [ForeignKey(nameof(Measurement))]
        public int NetfitID { get; set; }
    }
}
