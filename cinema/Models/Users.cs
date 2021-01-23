using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class Users
    {
        [Key]
        [Required]
        public string userName { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The email form is not acceptable, try again")]
        public string email { get; set; }
        [Required]
        public string userPassword { get; set; }
        public string permission { get; set; }
        public Users()
        {
            permission = "regular";

        }
    }
}