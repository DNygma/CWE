using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWE.Models
{
    public class User
    {
        public User()
        {
        }
        [Key]
        [Display(Name = "ID")]
        public string User_ID { get; set; }
    }
}
