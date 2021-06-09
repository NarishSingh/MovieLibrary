using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Models.API;

namespace MovieLibrary.Data
{
    /// <summary>
    /// Will interact with the external API
    /// </summary>
    public interface IMovieApi
    {
        /// <summary>
        /// Search for movies by title
        /// </summary>
        /// <param name="title">string for the movie title</param>
        /// <returns>Task with IEnumerable of movie short items, null if search fails</returns>
        Task<IEnumerable<MovieShortItem>> SearchByTitle(string title);

        /// <summary>
        /// Get details for a movie
        /// </summary>
        /// <param name="movieId">int for a valid movie entry</param>
        /// <returns>task MovieDetailedItem with info for a movie, null if search fails</returns>
        Task<MovieDetailedItem> SearchMovieById(int movieId);

        /// <summary>
        /// Get a list of movies currently playing
        /// </summary>
        /// <returns>Task IEnumerable of movie short items</returns>
        Task<IEnumerable<MovieShortItem>> SearchNowPlaying();
    }
}