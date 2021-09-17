using System.Collections.Generic;

namespace aspapp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}