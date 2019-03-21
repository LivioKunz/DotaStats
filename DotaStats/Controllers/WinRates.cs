using System;
using Newtonsoft.Json;

namespace DotaStats.Controllers
{
    [Serializable]
    public class WinRates
    {
        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
        public int games_played { get; set; }
        public int wins { get; set; }
    }
}