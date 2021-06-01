using System;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class MovieShortItem
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("release_date")] public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(ReleaseDate)}: {ReleaseDate}";
        }
    }
}