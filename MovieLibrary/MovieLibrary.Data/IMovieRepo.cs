using System.Collections;
using System.Collections.Generic;
using System.Threading;
using MovieLibrary.Models.Db;

namespace MovieLibrary.Data
{
    /// <summary>
    /// Will handle CRUD to the database
    /// </summary>
    public interface IMovieRepo
    {
        /// <summary>
        /// Create a new movie record in db
        /// </summary>
        /// <param name="movie">well form Movie obj</param>
        /// <returns>Successfully added movie from db</returns>
        Movie CreateMovie(Movie movie);

        /// <summary>
        /// Read a movie obj from db
        /// </summary>
        /// <param name="movieId">int for a valid movie id</param>
        /// <returns>Movie obj corresponding to that id</returns>
        Movie ReadMovieById(int movieId);

        /// <summary>
        /// Read all Movie obj's from db
        /// </summary>
        /// <returns>IEnumerable of all movies</returns>
        IEnumerable<Movie> ReadAllMovies();

        /// <summary>
        /// Update a movie record in db
        /// </summary>
        /// <param name="update">well formed Movie obj to be updated</param>
        /// <returns>Successfully updated movie from db</returns>
        Movie UpdateMovie(Movie update);

        /// <summary>
        /// Delete a movie record from Db
        /// </summary>
        /// <param name="movieId">valid id for a movie record in db</param>
        /// <returns>True if deleted, false if failed</returns>
        bool DeleteMovie(int movieId);
    }
}