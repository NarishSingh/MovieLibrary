using System;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class MovieShortItem
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("release_date")] public DateTime? ReleaseDate { get; set; }
        [JsonProperty("poster_path")] public string? PosterPath { get; set; }
    }
}