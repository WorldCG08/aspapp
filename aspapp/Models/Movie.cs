using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspapp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }
        public virtual List<Genre> Genres { get; set; }
        
    }
}