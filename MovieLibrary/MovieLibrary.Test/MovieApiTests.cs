using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task SearchByTitleTest()
        {
            IEnumerable<MovieShortItem> movies = await _movieApi.SearchByTitle("matrix");

            Assert.IsNotNull(movies);
            Assert.AreEqual(20, movies.Count());
            Assert.IsNotNull(movies.FirstOrDefault(m => m.Title == "The Matrix"));
        }

        [Test]
        public async Task SearchByTitleFail()
        {
            IEnumerable<MovieShortItem> noMovie = await _movieApi.SearchByTitle(" ");

            Assert.IsNull(noMovie);
        }

        [Test]
        public async Task SearchMovieByIdTest()
        {
            MovieDetailedItem movie = await _movieApi.SearchMovieById(603); //The Matrix

            Assert.IsNotNull(movie);
            Assert.AreEqual("The Matrix", movie.Title);
            Assert.AreEqual(2, movie.Directors.Count()); //check for directors api call
            Assert.AreEqual(3, movie.TrailerPaths.Count); //check for trailers api call
        }

        [Test]
        public async Task SearchByIdFail()
        {
            MovieDetailedItem noMovie = await _movieApi.SearchMovieById(0);

            Assert.IsNull(noMovie);
        }

        [Test]
        public async Task SearchNowPlayingTest()
        {
            IEnumerable<MovieShortItem> nowPlaying = await _movieApi.SearchNowPlaying();

            Assert.IsNotNull(nowPlaying);
            Assert.AreEqual(20, nowPlaying.Count());
        }
    }
}