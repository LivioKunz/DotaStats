using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotaStats.Controllers
{
    [Produces("application/json")]
    [Route("api/Dota")]
    public class DotaController : Controller
    {
        // GET
        [HttpGet]
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            var api = new OpenDotaApi();

            var heroesJson = api.GetHeroes();

            var heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesJson);
            return heroes;

        }
    }

    [Serializable]
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localized_name { get; set; }
        public string primary_attr { get; set; }
        public string attack_type { get; set; }
        public List<string> roles { get; set; }
        public int legs { get; set; }
    }
}