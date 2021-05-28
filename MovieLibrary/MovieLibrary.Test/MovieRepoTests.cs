using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MovieLibrary.Data;
using MovieLibrary.Models.Db;
using NUnit.Framework;

namespace MovieLibrary.Test
{
    [TestFixture]
    public class MovieRepoTests
    {
        private IMovieRepo _repo;

        [SetUp]
        public void Init()
        {
            _repo = new MovieRepoImpl();

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
        public void CreateMovieTest()
        {
            Movie test = new Movie
            {
                MovieTitle = "Test Insert"
            };

            Movie created = _repo.CreateMovie(test);
            IEnumerable<Movie> allMovies = _repo.ReadAllMovies();
            
            Assert.NotNull(created);
            Assert.AreEqual(4, allMovies.Count());
            Assert.AreEqual(4, created.MovieId);
            Assert.AreEqual("Test Insert", created.MovieTitle);
            Assert.AreEqual(0, created.Likes);
            Assert.AreEqual(0, created.Dislikes);
        }

        [Test]
        public void ReadMovieByIdTest()
        {
            Movie first = _repo.ReadMovieById(1);
            
            Assert.NotNull(first);
            Assert.AreEqual(1, first.MovieId);
            Assert.AreEqual("Test I", first.MovieTitle);
            Assert.AreEqual(1, first.Likes);
            Assert.AreEqual(5, first.Dislikes);
        }

        [Test]
        public void ReadByIdFail()
        {
            Movie fail = _repo.ReadMovieById(Int32.MaxValue);
            
            Assert.IsNull(fail);
        }

        [Test]
        public void ReadAllMoviesTest()
        {
            List<Movie> allMovies = _repo.ReadAllMovies().ToList();
            
            Assert.NotNull(allMovies);
            Assert.AreEqual(3, allMovies.Count);
            Assert.AreEqual(1, allMovies[0].MovieId);
            Assert.AreEqual(2, allMovies[1].MovieId);
            Assert.AreEqual(3, allMovies[2].MovieId);
        }
    }
}