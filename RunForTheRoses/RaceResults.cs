using Newtonsoft.Json;
using System;

namespace RunForTheRoses
{
    public class RaceResults
    {
        public string Track { get; set; }
        public DateTime? Date { get; set; }
        public string Race { get; set; }
        public string Win { get; set; }
        public string Place { get; set; }
        public string Show { get; set; }
        [JsonProperty(PropertyName = "4TH")]
        public string Fourth { get; set; }
    }
}
