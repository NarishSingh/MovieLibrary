using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Service;

namespace MovieLibrary.Service
{
    public interface IService
    {
        /// <summary>
        /// Get movies currently in theaters - for front page
        /// </summary>
        /// <returns>Task with IEnumerable of movie short items for now playing titles</returns>
        Task<IEnumerable<MovieShortItem>> SearchNowPlaying();

        /// <summary>
        /// Search for a movie by its title
        /// </summary>
        /// <param name="title">string for the title of the movie</param>
        /// <returns>Task with IEnumerable of movie short items for search results</returns>
        Task<IEnumerable<MovieShortItem>> SearchByTitle(string title);

        /// <summary>
        /// Get movie details
        /// </summary>
        /// <param name="id">int for valid movie id from MovieDb API</param>
        /// <returns>Task with Movie with all movie details and like/dislike counts</returns>
        Task<Movie> GetMovieById(int id);

        /// <summary>
        /// On like or dislike, persist movie entry to db
        /// </summary>
        /// <param name="m">Movie to be created or updated in db</param>
        /// <returns>Movie obj of the (dis)liked movie</returns>
        Movie PersistLikeDislike(Movie m);
    }
}