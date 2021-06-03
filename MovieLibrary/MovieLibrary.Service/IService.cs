using System.Collections.Generic;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Service;

namespace MovieLibrary.Service
{
    public interface IService
    {
        /// <summary>
        /// Get movies currently in theaters - for front page
        /// </summary>
        /// <returns>IEnumerable of movie short items for now playing titles</returns>
        IEnumerable<MovieShortItem> SearchNowPlaying();

        /// <summary>
        /// Search for a movie by its title
        /// </summary>
        /// <param name="title">string for the title of the movie</param>
        /// <returns>IEnumerable of movie short items for search results</returns>
        IEnumerable<MovieShortItem> SearchByTitle(string title);
        
        /// <summary>
        /// Get movie details
        /// </summary>
        /// <param name="id">int for movie id</param>
        /// <returns>Movie with all movie details and like/dislike counts</returns>
        Movie GetMovieById(int id);

        /// <summary>
        /// Add a like to a movie, persist to db by creating or updating an entry
        /// </summary>
        /// <param name="id">int for movie id</param>
        /// <returns>the Movie of the liked movie</returns>
        Movie LikeMovie(int id);

        /// <summary>
        /// Add a dislike to a movie, persist to db by creating or updating an entry
        /// </summary>
        /// <param name="id">int for movie id</param>
        /// <returns>the Movie of the disliked movie</returns>
        Movie DislikeMovie(int id);
    }
}