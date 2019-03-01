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
        [Route("api/Counters/{names}")]
        public async  Task<HeroCounter> GetHeroesCounters(List<string> names)
        {
            var name = names.First();
            var api = new OpenDotaApi();
            var heroesJson = api.GetHeroes();

            var heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesJson);
            var searchedHero = heroes.SingleOrDefault(x => x.localized_name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            var winRateHeroes = api.GetWinrateForHero(searchedHero.id);
            var heroesWinrate = JsonConvert.DeserializeObject<List<WinRates>>(winRateHeroes);

            var bestWinrates = heroesWinrate.Where(x => x.games_played > 5).OrderByDescending(x => x.wins).Take(9).Select(x => x.hero_id);
            
            var heroCounters = new List<Hero>();
            
            foreach (var heroId in bestWinrates)
            {
                heroCounters.Add(heroes.SingleOrDefault(x => x.id == heroId));
            }

            return new HeroCounter
            {
                name = searchedHero.localized_name,
                SearchedHero = searchedHero,
                HeroCounters = heroCounters
            };
        }
    }

    [Serializable]
    public class HeroCounter
    {
        public string name { get; set; }

        public Hero SearchedHero { get; set; }

        public IEnumerable<Hero> HeroCounters { get; set; }
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