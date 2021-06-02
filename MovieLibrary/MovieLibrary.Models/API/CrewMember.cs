using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class CrewMember
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("job")] public string Job { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}