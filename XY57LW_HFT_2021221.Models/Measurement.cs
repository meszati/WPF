using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY57LW_HFT_2021221.Models
{
    [Table("measurements")]
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public double BMI { get; set; }

        [Required]
        public int Pushup { get; set; }

        [Required]
        public int Situp { get; set; }

        public int Jump { get; set; }

        public double Bodyfat { get; set; }

        [NotMapped]
        public virtual Student Student { get; set; }


    }
}
