using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class CrewMember
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("known_for_department")] public string Dept { get; set; }
        [JsonProperty("name")] public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Dept)}: {Dept}, {nameof(Name)}: {Name}";
        }
    }
}