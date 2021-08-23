using System.Collections.Generic;
using aspapp.Models;

namespace aspapp.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}