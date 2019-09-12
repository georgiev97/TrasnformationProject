using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity
{
    public class Workout 
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Display(Name = "Monday")]

        public string Monday { get; set; }

        [Display(Name = "Tuesday")]

        public string Tuesday { get; set; }

        [Display(Name = "Wednesday")]

        public string Wednesday { get; set; }

        [Display(Name = "Thursday")]

        public string Thursday { get; set; }

        [Display(Name = "Friday")]

        public string Friday { get; set; }

        [Display(Name = "Saturday")]

        public string Saturday { get; set; }

        [Display(Name = "Sunday")]

        public string Sunday { get; set; }


        public virtual User User { get; set; }

    }
}
