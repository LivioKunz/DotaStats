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
        public async  Task<HeroCounter> GetHeroesCounters(string names)
        {
            //var Name = names.First();
            var api = new OpenDotaApi();
            var heroesJson = api.GetHeroes();


            var heroes = JsonConvert.DeserializeObject<List<Hero>>(heroesJson);
            
            var splittedHeroNames = names.Split(',');
            var allWinrates = new List<WinRates>();

            var searchedHeroNames = new List<string>();
            foreach (string name in splittedHeroNames)
            {

                var searchedHero = heroes.SingleOrDefault(x =>
                    x.localized_name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                
                searchedHeroNames.Add(searchedHero.localized_name);

                var winRateHeroes = api.GetWinrateForHero(searchedHero.Id);
                var heroesWinrate = JsonConvert.DeserializeObject<List<WinRates>>(winRateHeroes);

                allWinrates.AddRange(heroesWinrate.Where(x => x.games_played > 5).OrderByDescending(x => x.wins / x.games_played).Take(9));
            }

            var heroCounters = new List<Hero>();
            foreach (var heroId in allWinrates.OrderByDescending(x => x.wins / x.games_played).Take(9).Select(x => x.HeroId))
            {
                var hero = heroes.SingleOrDefault(x => x.Id == heroId);
                hero.ImageName = hero.localized_name.Replace(' ', '_');
                heroCounters.Add(hero);
            }

            return new HeroCounter
            {
                Name = string.Join(',',searchedHeroNames),
                HeroCounters = heroCounters
            };
        }
    }
}