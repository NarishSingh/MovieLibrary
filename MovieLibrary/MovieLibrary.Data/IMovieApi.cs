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
        /// <returns>Task with IEnumerable of movie short items</returns>
        Task<IEnumerable<MovieShortItem>> SearchByTitle(string title);
    }
}