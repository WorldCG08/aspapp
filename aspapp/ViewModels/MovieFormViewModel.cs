using System.Collections.Generic;
using System.Web.Mvc;
using aspapp.Models;

namespace aspapp.ViewModels
{
    public class MovieFormViewModel
    {
        public MultiSelectList Genres { get; set; }
        public int[] SelectedGenres { get; set; }
        public Movie Movie { get; set; }
    }
}