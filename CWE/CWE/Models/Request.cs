using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWE.Models
{
    public class Request
    {
        public Request()
        {
        }

        [Key]
        [Display(Name = "ID")]
        public string Request_ID { get; set; }
        [Display(Name = "Pair")]
        public string Request_Pair { get; set; }
        [Display(Name = "Target Rate")]
        public string Request_TargetRte { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
