﻿using System.Net.Http;
using System.Threading.Tasks;

namespace DotaStats
{
    public class OpenDotaApi : IOpenDotaApi
    {
        public string GetMatchById(string id)
        {
            var response = GetMatch(id);
            return response.Result;
        }

        private async Task<string> GetMatch(string id)
        {
            var url = $"https://api.opendota.com/api/matches/{id}";
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
        string GetMatchById(string id);
    }
}