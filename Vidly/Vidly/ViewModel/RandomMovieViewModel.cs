using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customers> Customers { get; set; }
    }
}