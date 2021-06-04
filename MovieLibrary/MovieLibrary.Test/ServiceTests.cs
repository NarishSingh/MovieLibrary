using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MovieLibrary.Data;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Service;
using MovieLibrary.Service;
using NUnit.Framework;

namespace MovieLibrary.Test
{
    [TestFixture]
    public class ServiceTests
    {
        private IService _service;

        [SetUp]
        public void Init()
        {
            _service = new ServiceImpl();

            //reset db to a known state for each test
            using (SqlConnection c = new SqlConnection(Settings.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = c,
                    CommandText = "DbReset",
                    CommandType = CommandType.StoredProcedure
                };

                c.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void SearchNowPlayingTest()
        {
            IEnumerable<MovieShortItem> nowPlaying = _service.SearchNowPlaying();

            Assert.IsNotNull(nowPlaying);
            Assert.AreEqual(20, nowPlaying.Count());
        }
        
        [Test]
        public void SearchByTitleTest()
        {
            IEnumerable<MovieShortItem> movies = _service.SearchByTitle("matrix");

            Assert.IsNotNull(movies);
            Assert.AreEqual(20, movies.Count());
            Assert.IsNotNull(movies.FirstOrDefault(m => m.Title == "The Matrix"));
        }
        
        [Test]
        public void SearchByTitleFail()
        {
            IEnumerable<MovieShortItem> noMovie = _service.SearchByTitle(" ");
            
            Assert.IsNull(noMovie);
        }

        [Test]
        public void SearchMovieByIdTest()
        {
            //(4, 'The Matrix', 1, 0) - ApiId = 603
            Movie matrix = _service.GetMovieById(603);

            Assert.IsNotNull(matrix);
            Assert.IsNotNull(matrix.RepoId);
            Assert.AreEqual(4, matrix.RepoId);
            Assert.AreEqual("The Matrix", matrix.Title);
            Assert.AreEqual(new List<string> {"Lilly Wachowski", "Lana Wachowski"}, matrix.Directors);
            Assert.AreEqual(DateTime.Parse("1999-03-30"), matrix.ReleaseDate);
            Assert.AreEqual(
                "Set in the 22nd century, The Matrix tells the story of a computer hacker who joins a group of " +
                "underground insurgents fighting the vast and powerful computers who now rule the earth.",
                matrix.Description);
            Assert.AreEqual("https://image.tmdb.org/t/p/w500/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg", matrix.PosterPath);
            Assert.AreEqual(1, matrix.Likes);
            Assert.AreEqual(0, matrix.Dislikes);
        }
    }
}