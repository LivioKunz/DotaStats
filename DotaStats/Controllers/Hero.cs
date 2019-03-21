using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaStats.Controllers
{
    [Serializable]
    public class Hero
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        public string localized_name { get; set; }
        public string primary_attr { get; set; }
        public string attack_type { get; set; }
        public List<string> roles { get; set; }
        public int legs { get; set; }
        public string ImageName { get; set; }
        public string winRateFavor { get; set; }
    }
}