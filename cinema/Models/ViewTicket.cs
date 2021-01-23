using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class ViewTicket
    {
        public int row { get; set; }
        public int col { get; set; }
        public string taken { get; set; }
        public string movieName { get; set; }
        public string sHour { get; set; }
        public string sDate { get; set; }
        public string hall { get; set; }
    }
}