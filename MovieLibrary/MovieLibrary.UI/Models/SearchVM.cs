using System.Collections.Generic;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Service;

namespace MovieLibrary.UI.Models
{
    public class SearchVM
    {
        public IEnumerable<Movie> Top3 { get; set; }
        public IEnumerable<MovieShortItem> Results { get; set; }
    }
}