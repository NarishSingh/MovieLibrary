using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class MovieShortItem
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("original_title")] public string Title { get; set; }
        [JsonProperty("release_date")] public string ReleaseDate { get; set; }
    }
}