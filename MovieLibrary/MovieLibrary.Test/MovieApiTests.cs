using System.Collections.Generic;
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
            IEnumerable<MovieShortItem> movies = _movieApi.SearchByTitle("matrix").Result; //use result to get the IEnumerable out of the task

            Assert.IsNotNull(movies);
        }
    }
}