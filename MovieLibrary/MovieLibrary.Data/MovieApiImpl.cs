using System;
using System.Collections.Generic;
using System.Linq;
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
        private const string ImagePath = "https://image.tmdb.org/t/p/w500"; //default 500px width

        public async Task<IEnumerable<MovieShortItem>> SearchByTitle(string title)
        {
            SearchResults movieList = new SearchResults();

            //create the request - GET movies by title
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={ApiKey}&language=en-US" +
                                     $"&query={title}&page=1&include_adult=false")
            };

            //send request, await
            using (HttpResponseMessage response = await Client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    //convert JSON to string and deserialize to root JSON array container obj
                    string body = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<SearchResults>(body);
                    
                    //process movie poster paths
                    foreach (MovieShortItem movie in movieList.Movies)
                    {
                        movie.PosterPath = movie.PosterPath != null ? ImagePath + movie.PosterPath : null;
                    }
                }
            }
            
            return movieList.Movies; //return the IEnumerable
        }

        public async Task<MovieDetailedItem> SearchMovieById(int movieId)
        {
            MovieDetailedItem movie = null;

            //GET movie details
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movieId}?api_key={ApiKey}&language=en-US")
            };

            using (HttpResponseMessage response = await Client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<MovieDetailedItem>(body);

                    //GET movie crew details and find directors
                    HttpRequestMessage crewRequest = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri =
                            new Uri(
                                $"https://api.themoviedb.org/3/movie/{movieId}/credits?api_key={ApiKey}&language=en-US")
                    };

                    using (HttpResponseMessage crewResponse = await Client.SendAsync(crewRequest))
                    {
                        string crewBody = await crewResponse.Content.ReadAsStringAsync();
                        Crew crew = JsonConvert.DeserializeObject<Crew>(crewBody);

                        //LINQ to find director names
                        movie.Directors = crew.CrewMembers
                            .Where(crewMember => crewMember.Job == "Director")
                            .Select(director => director.Name);
                    }
                    
                    movie.PosterPath = movie.PosterPath != null ? ImagePath + movie.PosterPath : null;
                }
            }

            return movie;
        }

        public async Task<IEnumerable<MovieShortItem>> SearchNowPlaying()
        {
            SearchResults nowPlaying;

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri($"https://api.themoviedb.org/3/movie/now_playing?api_key={ApiKey}&language=en-US&page=1")
            };

            using (HttpResponseMessage response = await Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();
                nowPlaying = JsonConvert.DeserializeObject<SearchResults>(body);
                
                //process movie poster paths
                foreach (MovieShortItem movie in nowPlaying.Movies)
                {
                    movie.PosterPath = movie.PosterPath != null ? ImagePath + movie.PosterPath : null;
                }
            }

            return nowPlaying.Movies;
        }
    }
}