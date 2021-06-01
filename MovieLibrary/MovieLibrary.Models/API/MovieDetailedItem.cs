using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Detail Item DTO's for API that read one by id
    /// </summary>
    public class MovieDetailedItem
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        public IEnumerable<string> Directors { get; set; } //Not a JSON property, will need a separate API call
        [JsonProperty("release_date")] public DateTime ReleaseDate { get; set; }
        [JsonProperty("overview")] public string Description { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Directors)}: {Directors}, {nameof(ReleaseDate)}: {ReleaseDate}, {nameof(Description)}: {Description}";
        }
    }
}