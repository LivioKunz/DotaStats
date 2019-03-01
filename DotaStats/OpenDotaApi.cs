using System.Net.Http;
using System.Threading.Tasks;

namespace DotaStats
{
    public class OpenDotaApi : IOpenDotaApi
    {
        public string GetMatchById(string id)
        {
            var url = $"https://api.opendota.com/api/matches/{id}";
            var response = this.GetFromUrl(url);
            return response.Result;
        }

        public string GetHeroes()
        {
            var url = $"https://api.opendota.com/api/heroes";
            
            var response = GetFromUrl(url);
            return response.Result;
        }

        public string GetWinrateForHero(int id)
        {
            var url = $"https://api.opendota.com/api/heroes/{id}/matchups";

            var response = GetFromUrl(url);
            return response.Result;
        }

        private async Task<string> GetFromUrl(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var test = await response.Content.ReadAsStringAsync();
                return test;
            }

            return null;
        }
    }

    public interface IOpenDotaApi
    {
    }
}