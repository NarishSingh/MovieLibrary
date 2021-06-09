using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task SearchNowPlayingTest()
        {
            IEnumerable<MovieShortItem> nowPlaying = await _service.SearchNowPlaying();

            Assert.IsNotNull(nowPlaying);
            Assert.AreEqual(20, nowPlaying.Count());
        }
        
        [Test]
        public async Task SearchByTitleTest()
        {
            IEnumerable<MovieShortItem> movies = await _service.SearchByTitle("matrix");

            Assert.IsNotNull(movies);
            Assert.AreEqual(20, movies.Count());
            Assert.IsNotNull(movies.FirstOrDefault(m => m.Title == "The Matrix"));
        }
        
        [Test]
        public async Task SearchByTitleFail()
        {
            IEnumerable<MovieShortItem> noMovie = await _service.SearchByTitle(" ");
            
            Assert.IsNull(noMovie);
        }

        [Test]
        public async Task SearchMovieByIdTest()
        {
            //(4, 'The Matrix', 1, 0) - ApiId = 603
            Movie matrix = await _service.GetMovieById(603);

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
        
        [Test]
        public async Task SearchByIdFail()
        {
            Movie fail = await _service.GetMovieById(int.MaxValue);

            Assert.IsNull(fail);
        }

        [Test]
        public async Task PersistLikeTest()
        {
            Movie matrix = await _service.GetMovieById(603);
            
            matrix.Likes++;
            Movie addedLike = _service.PersistLikeDislike(matrix);
            Assert.IsNotNull(addedLike);
            Assert.AreEqual(2, addedLike.Likes);
            Assert.AreEqual(0, addedLike.Dislikes);

            matrix.Likes--;
            Movie removedLike = _service.PersistLikeDislike(matrix);
            Assert.IsNotNull(removedLike);
            Assert.AreEqual(1, removedLike.Likes);
            Assert.AreEqual(0, removedLike.Dislikes);
        }

        [Test]
        public async Task PersistDislikeTest()
        {
            Movie matrix = await _service.GetMovieById(603);
            
            matrix.Dislikes++;
            Movie addedDislike = _service.PersistLikeDislike(matrix);
            Assert.IsNotNull(addedDislike);
            Assert.AreEqual(1, addedDislike.Likes);
            Assert.AreEqual(1, addedDislike.Dislikes);

            matrix.Dislikes--;
            Movie removedDislike = _service.PersistLikeDislike(matrix);
            Assert.IsNotNull(removedDislike);
            Assert.AreEqual(1, removedDislike.Likes);
            Assert.AreEqual(0, removedDislike.Dislikes);
        }
    }
}