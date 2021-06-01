using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieLibrary.Models.API
{
    public class Cast
    {
        [JsonProperty("cast")] public List<CrewMember> CrewMembers { get; set; }

        public override string ToString()
        {
            return $"{nameof(CrewMembers)}: {CrewMembers}";
        }
    }
}