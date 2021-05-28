﻿using MovieLibrary.Models.Db;

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
        void CreateMovie(Movie movie);

        /// <summary>
        /// Read a movie obj from db
        /// </summary>
        /// <param name="movieId">int for a valid movie id</param>
        /// <returns>Movie obj corresponding to that id</returns>
        Movie ReadMovieById(int movieId);

        /// <summary>
        /// Update a movie record in db
        /// </summary>
        /// <param name="update">well formed Movie obj to be updated</param>
        void UpdateMovie(Movie update);

        /// <summary>
        /// Delete a movie record from Db
        /// </summary>
        /// <param name="movieId">valid id for a movie record in db</param>
        void DeleteMovie(int movieId);
    }
}