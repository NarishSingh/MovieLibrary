using System;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Short item DTO's for API's that return IEnumerables
    /// </summary>
    public class MovieShortItem
    {
        [JsonProperty("imdb_id")] public string ImdbId { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("year")] public string Year { get; set; }
    }
}