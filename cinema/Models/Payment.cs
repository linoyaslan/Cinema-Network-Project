using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class Payment
    {
        [Required]
        [RegularExpression("^4[0 - 9]{12}(?:[0-9]{3})?$", ErrorMessage ="The number is not legal")]
        public string creditCard { get; set; }
        [Required]
        public string validityM { get; set; }
        [Required]
        public string validityY { get; set; }
        [Required]
        public string ccv { get; set; }

    }
}