using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWE.Models
{
    public class Scheduler
    {
        public Scheduler()
        {

        }

        [Key]
        [Display(Name = "ID")]
        public string Scheduler_UserID { get; set; }
        [Display(Name = "Pair")]
        public string Scheduler_Pair { get; set; }
        [Display(Name = "Requesting Rate")]
        public double Scheduler_RequestRate { get; set; }
        [Display(Name = "Target Rate")]
        public double Scheduler_TargetRate { get; set; }
        [Display(Name = "Actual Rate")]
        public double Scheduler_ActualRate { get; set; }
    }
}
