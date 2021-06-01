using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class Crew
    {
        [JsonProperty("crew")] public List<CrewMember> CrewMembers { get; set; }

        public override string ToString()
        {
            return $"{nameof(CrewMembers)}: {CrewMembers}";
        }
    }
}