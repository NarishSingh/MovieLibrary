using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Detailed Item DTO's for API that read one by id
    /// </summary>
    public class MovieDetailedItem
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        public IEnumerable<string> Directors { get; set; } //Not a JSON property, will need a separate API call
        [JsonProperty("release_date")] public DateTime? ReleaseDate { get; set; }
        [JsonProperty("overview")] public string Description { get; set; }
        [JsonProperty("poster_path")] public string PosterPath { get; set; } //https://image.tmdb.org/t/p/w + width int + / + this prop for poster image
    }
}