using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Trailer request root JSON container
    /// </summary>
    public class TrailerResults
    {
        [JsonProperty("id")] public int MovieId { get; set; }
        [JsonProperty("results")] public IEnumerable<Trailer> Trailers { get; set; }
    }
}