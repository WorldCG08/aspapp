using System;
using System.Collections.Generic;

namespace aspapp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Genre> Genres { get; set; }
    }
}