using System;
using System.Net.Http;
using System.Threading.Tasks;
using DotaStats;
using Xunit;
using FluentAssertions;

namespace DotaStatsTest
{
    public class OpenDotaApiTests
    {
        [Fact]
        public void GetMatch()
        {
            //Get Match info with match_id: 1483994292
            var testee = new OpenDotaApi();
            var result = testee.GetMatchById("1483994292");

            result.Should().NotBeEmpty();

        }

        [Fact]
        public void GetHeroes()
        {
            var testee = new OpenDotaApi();
            var result = testee.GetHeroes();

            result.Should().NotBeEmpty();
        }
       
    }

}
