using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class GalleryModel
    {
        public Movies movie { get; set; }
        public Screenings screenings { get; set; }
    }
}