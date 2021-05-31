using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class SearchResults
    {
        [JsonProperty("results")] public IEnumerable<MovieShortItem> Movies { get; set; }
    }
}