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
        private static readonly HttpClient Client = new HttpClient();
        private const string ApiKey = "d5150b3ec8f4f8de295a897de8623169";
        
        public async Task<IEnumerable<MovieShortItem>> SearchByTitle(string title)
        {
            SearchResults movieList;
            
            //create the request
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://api.themoviedb.org/3/search/movie?api_key={ApiKey}&language=en-US&query={title}&page=1&include_adult=false")
            };

            //send request, await
            using (HttpResponseMessage response = await Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                //convert JSON to string and deserialize to root JSON array container obj
                string body = await response.Content.ReadAsStringAsync();
                movieList = JsonConvert.DeserializeObject<SearchResults>(body);
            }

            return movieList.Movies; //return the IEnumerable
        }
    }
}