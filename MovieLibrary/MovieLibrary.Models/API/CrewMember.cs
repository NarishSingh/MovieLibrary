using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class CrewMember
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("job")] public string Job { get; set; }
        [JsonProperty("name")] public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Job)}: {Job}, {nameof(Name)}: {Name}";
        }
    }
}