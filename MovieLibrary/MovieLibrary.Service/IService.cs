using System.Collections.Generic;
using MovieLibrary.Models.API;
using MovieLibrary.Models.ViewModels;

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
        /// <returns>MovieVM with all movie details and like/dislike counts</returns>
        MovieVM GetMovieById(int id);

        /// <summary>
        /// Add a like to a movie, persist to db by creating or updating an entry
        /// </summary>
        /// <param name="id">int for movie id</param>
        /// <returns>the MovieVM of the liked movie</returns>
        MovieVM LikeMovie(int id);

        /// <summary>
        /// Add a dislike to a movie, persist to db by creating or updating an entry
        /// </summary>
        /// <param name="id">int for movie id</param>
        /// <returns>the MovieVM of the disliked movie</returns>
        MovieVM DislikeMovie(int id);
    }
}