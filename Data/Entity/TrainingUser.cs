using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity
{


    public class TrainingUser 
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [ForeignKey("User")]
        public  int? UserId {get;set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Display(Name = "Height")]
        [Required(ErrorMessage = "Height required")]
        public int Height { get; set; }

        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Weight required")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Level required")]
        public string Level { get; set; }

        [Column]
        public double? Rating { get; set; }

        public virtual User User { get; set; }

       

        


    }
}
