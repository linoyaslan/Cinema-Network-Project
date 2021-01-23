using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class Hall
    {
        [Key]
        public string hall { get; set; }
        public string numOfRows { get; set; }
        public string numOfSeats { get; set; }
    }
}