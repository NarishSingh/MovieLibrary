using System;
using System.Collections.Generic;
using System.Linq;
using MovieLibrary.Data;
using MovieLibrary.Models.API;
using NUnit.Framework;

namespace MovieLibrary.Test
{
    [TestFixture]
    public class MovieApiTests
    {
        private IMovieApi _movieApi;

        [SetUp]
        public void Init()
        {
            _movieApi = new MovieApiImpl();
        }

        [Test]
        public void SearchByTitleTest()
        {
            IEnumerable<MovieShortItem> movies = _movieApi.SearchByTitle("matrix");

            Assert.IsNotNull(movies);
            Assert.AreEqual(20, movies.Count());
        }

        [Test]
        public void SearchMovieByIdTest()
        {
            MovieDetailedItem movie = _movieApi.GetMovieById(603); //The Matrix
            
            Assert.IsNotNull(movie);
            Assert.AreEqual("The Matrix", movie.Title);
            Assert.IsNotNull(movie.Directors); //check for 2nd api call
        }
    }
}