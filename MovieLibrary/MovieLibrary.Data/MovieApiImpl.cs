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

        public IEnumerable<MovieShortItem> SearchByTitle(string title)
        {
            Task<IEnumerable<MovieShortItem>> task = Task<IEnumerable<MovieShortItem>>.Factory
                .StartNew(() => GetSearch(title).Result);
            return task.Result; //use result to get the IEnumerable out of the task
        }

        public MovieDetailedItem SearchMovieById(int movieId)
        {
            Task<MovieDetailedItem> task = Task<MovieDetailedItem>.Factory
                .StartNew(() => GetMovieDetails(movieId).Result);
            return task.Result;
        }

        public IEnumerable<MovieShortItem> SearchNowPlaying()
        {
            Task<IEnumerable<MovieShortItem>> task = Task<IEnumerable<MovieShortItem>>.Factory
                .StartNew(() => GetNowPlaying().Result);
            return task.Result;
        }

        /*TASKS*/
        /// <summary>
        /// Perform search using the MovieDb API
        /// </summary>
        /// <param name="title">Title string to search for</param>
        /// <returns>Task which</returns>
        private async Task<IEnumerable<MovieShortItem>> GetSearch(string title)
        {
            SearchResults movieList;

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
                response.EnsureSuccessStatusCode();

                //convert JSON to string and deserialize to root JSON array container obj
                string body = await response.Content.ReadAsStringAsync();
                movieList = JsonConvert.DeserializeObject<SearchResults>(body);
            }

            return movieList.Movies; //return the IEnumerable
        }

        /// <summary>
        /// Get details for a movie
        /// </summary>
        /// <param name="movieId">int for a valid movie id</param>
        /// <returns>Task with the MovieDetailedItem with movie info</returns>
        private async Task<MovieDetailedItem> GetMovieDetails(int movieId)
        {
            MovieDetailedItem movie;

            //GET movie details
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movieId}?api_key={ApiKey}&language=en-US")
            };

            using (HttpResponseMessage response = await Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<MovieDetailedItem>(body);
            }

            //GET movie crew details and find directors
            HttpRequestMessage crewRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri($"https://api.themoviedb.org/3/movie/{movieId}/credits?api_key={ApiKey}&language=en-US")
            };

            using (HttpResponseMessage crewResponse = await Client.SendAsync(crewRequest))
            {
                string body = await crewResponse.Content.ReadAsStringAsync();
                Crew crew = JsonConvert.DeserializeObject<Crew>(body);

                //LINQ to find director names
                movie.Directors = crew.CrewMembers
                    .Where(crewMember => crewMember.Job == "Director")
                    .Select(director => director.Name);
            }

            return movie;
        }

        /// <summary>
        /// Get movies currently playing
        /// </summary>
        /// <returns>Task with a IEnumerable of movie short items</returns>
        private async Task<IEnumerable<MovieShortItem>> GetNowPlaying()
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
            }

            return nowPlaying.Movies;
        }
    }
}