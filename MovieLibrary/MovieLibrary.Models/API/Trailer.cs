using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Trailer video info
    /// </summary>
    public class Trailer
    {
        [JsonProperty("name")] public string TrailerName { get; set; }
        [JsonProperty("site")] public string Site { get; set; }
        [JsonProperty("key")] public string Key { get; set; }
    }
}