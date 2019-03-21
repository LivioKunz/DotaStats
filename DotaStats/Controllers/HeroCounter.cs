using System;
using System.Collections.Generic;

namespace DotaStats.Controllers
{
    [Serializable]
    public class HeroCounter
    {
        public string Name { get; set; }

        public Hero SearchedHero { get; set; }

        public IEnumerable<Hero> HeroCounters { get; set; }
    }
}