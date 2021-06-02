using System.Collections.Generic;
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
        /// <returns>IEnumerable of movie short items</returns>
        IEnumerable<MovieShortItem> SearchByTitle(string title);

        /// <summary>
        /// Get details for a movie
        /// </summary>
        /// <param name="movieId">int for a valid movie entry</param>
        /// <returns>MovieDetailedItem with info for a movie</returns>
        MovieDetailedItem SearchMovieById(int movieId);

        /// <summary>
        /// Get a list of movies currently playing
        /// </summary>
        /// <returns>IEnumerable of movie short items</returns>
        IEnumerable<MovieShortItem> SearchNowPlaying();
    }
}