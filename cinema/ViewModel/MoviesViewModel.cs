using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cinema.Models;
using cinema.Dal;

namespace cinema.ViewModel
{
    public class MoviesViewModel
    {
        public Movies movie { get; set; }

        public List<Movies> movies { get; set; }
    }
}