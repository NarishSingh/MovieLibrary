using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    /// <summary>
    /// Container for the JSON array of crew member details
    /// </summary>
    public class Crew
    {
        [JsonProperty("crew")] public List<CrewMember> CrewMembers { get; set; }
    }
}