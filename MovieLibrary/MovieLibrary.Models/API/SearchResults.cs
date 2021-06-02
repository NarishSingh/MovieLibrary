using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Container for the JSON array of search results
    /// </summary>
    public class SearchResults
    {
        [JsonProperty("results")] public IEnumerable<MovieShortItem> Movies { get; set; }
        [JsonProperty("total_pages")] public int TotalPages { get; set; }
        [JsonProperty("total_results")] public int TotalResults { get; set; }
    }
}