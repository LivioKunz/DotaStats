using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotaStats.Controllers
{
    [Produces("application/json")]
    public class DotaController : Controller
    {
        // GET
        [HttpGet]
        [Route("api/Hero")]
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            var api = new OpenDotaApi();

            var heroesJson = api.GetHeroes();

            var heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesJson);
            return heroes;

        }

        [HttpGet]
        [Route("api/Hero/{name}")]
        public async Task<IEnumerable<Hero>> GetHeroes(string name)
        {
            var api = new OpenDotaApi();

            var heroesJson = api.GetHeroes();

            var heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesJson);
            var searchedHero = heroes.SingleOrDefault(x => x.localized_name == name);

            var winRateHeroes =
                JsonConvert.DeserializeObject<List<WinRates>>(
                    $"https://api.opendota.com/api/heroes/{searchedHero.id}/matchups");

            var bestWinrates = winRateHeroes.Where(x => x.games_played > 10).OrderBy(x => x.wins).Take(10);

            var worstWinrates = winRateHeroes.Where(x => x.games_played > 10).OrderByDescending(x => x.wins).Take(10);

            var returnList = new List<Hero>();
            returnList.Add(searchedHero);
            //todo listen zusammenführen und helden zurückgeben
            //var bestWinratesHeroes = 

            return returnList;

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

        public string winRateFavor { get; set; }
    }

    [Serializable]
    public class WinRates
    {
        public int hero_id { get; set; }
        public int games_played { get; set; }
        public int wins { get; set; }
    }
}