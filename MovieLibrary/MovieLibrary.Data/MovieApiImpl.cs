using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MovieLibrary.Models.API;
using Newtonsoft.Json;

namespace MovieLibrary.Data
{
    public class MovieApiImpl : IMovieApi
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<IEnumerable<MovieShortItem>> SearchByTitle(string title)
        {
            //create the request
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri("https://movies-tvshows-data-imdb.p.rapidapi.com/?type=get-movies-by-title&title=" + title),
                Headers =
                {
                    {"x-rapidapi-key", "371cd804d8msh7d4ca342b6db26bp1a9a5djsn72ffd3827026"},
                    {"x-rapidapi-host", "movies-tvshows-data-imdb.p.rapidapi.com"}
                }
            };

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<MovieShortItem>>(body);
            }
        }
    }
}