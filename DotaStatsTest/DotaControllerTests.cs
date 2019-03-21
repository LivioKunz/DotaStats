using System.Linq;
using DotaStats.Controllers;
using FluentAssertions;
using Xunit;

namespace DotaStatsTest
{
    public class DotaControllerTests
    {
        [Fact]
        public void GetHeroesCounterForSingleHero()
        {
            var testee = new DotaController();
            var result = testee.GetHeroesCounters("Slark");

            result.Result.SearchedHero.Id.Should().Be(93);
            result.Result.HeroCounters.Count().Should().Be(10);
            result.Result.HeroCounters.First().Id.Should().Be(11);
            result.Result.HeroCounters.Last().Id.Should().Be(33);

        }
    }
}