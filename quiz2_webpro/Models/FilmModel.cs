using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//testing
namespace quiz2_webpro.Models
{
    public class FilmModel
    {
        public int id_film { get; set; }

        [Display(Name = "Name")]
        public string name_film { get; set; }

        [Display(Name = "Distributor")]
        public string distributor_film { get; set; }

        [Display(Name = "Genre")]
        public string genre_film { get; set; }

        [Display(Name = "Year")]
        public int year_film { get; set; }

        [Display(Name = "Country")]
        public string country_film { get; set; }

        [Display(Name = "Duration")]
        public string duration_film { get; set; }

        [Display(Name = "Trailer")]
        public string trailer_film { get; set; }
    }
}