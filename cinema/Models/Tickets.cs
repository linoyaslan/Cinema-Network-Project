using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class Tickets
    {
        public string movieName { get; set; }
        [Key, Column(Order = 1)]
        public string numOfSeat { get; set; }
        [Key, Column(Order = 2)]
        public string numOfRow { get; set; }
        [Key, Column(Order = 3)]
        public string sDate { get; set; }
        [Key, Column(Order = 4)]
        public string sHour { get; set; }
        [Key, Column(Order = 5)]
        public string hall { get; set; }

    }
}