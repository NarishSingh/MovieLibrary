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
            MovieDb test = new MovieDb
            {
                MovieTitle = "Test Insert"
            };

            MovieDb created = _repo.CreateMovie(test);
            IEnumerable<MovieDb> allMovies = _repo.ReadAllMovies();

            Assert.NotNull(created);
            Assert.AreEqual(4, allMovies.Count());
            Assert.AreEqual(4, created.MovieId);
            Assert.AreEqual("Test Insert", created.MovieTitle);
            //db should default to 0 likes and dislikes
            Assert.AreEqual(0, created.Likes);
            Assert.AreEqual(0, created.Dislikes);
        }

        [Test]
        public void ReadMovieByIdTest()
        {
            MovieDb first = _repo.ReadMovieById(1);

            Assert.NotNull(first);
            Assert.AreEqual(1, first.MovieId);
            Assert.AreEqual("Test I", first.MovieTitle);
            Assert.AreEqual(1, first.Likes);
            Assert.AreEqual(5, first.Dislikes);
        }

        [Test]
        public void ReadByIdFail()
        {
            MovieDb fail = _repo.ReadMovieById(int.MaxValue);

            Assert.IsNull(fail);
        }

        [Test]
        public void ReadAllMoviesTest()
        {
            List<MovieDb> allMovies = _repo.ReadAllMovies().ToList();

            Assert.NotNull(allMovies);
            Assert.AreEqual(3, allMovies.Count);
            Assert.AreEqual(1, allMovies[0].MovieId);
            Assert.AreEqual(2, allMovies[1].MovieId);
            Assert.AreEqual(3, allMovies[2].MovieId);
        }

        [Test]
        public void UpdateMovieTest()
        {
            MovieDb original = _repo.ReadMovieById(1);
            MovieDb test = _repo.ReadMovieById(1);
            test.Likes++;
            test.Dislikes--;

            MovieDb updated = _repo.UpdateMovie(test);

            Assert.NotNull(updated);
            Assert.AreEqual(updated.MovieId, original.MovieId);
            Assert.AreEqual(updated.MovieTitle, original.MovieTitle);
            Assert.AreNotEqual(updated.Likes, original.Likes);
            Assert.AreEqual(2, updated.Likes);
            Assert.AreNotEqual(updated.Dislikes, original.Dislikes);
            Assert.AreEqual(4, updated.Dislikes);
        }

        [Test]
        public void UpdateFail()
        {
            MovieDb badMovieDb = new MovieDb
            {
                MovieId = Int32.MinValue,
                MovieTitle = "Bad Movie",
                Likes = -99,
                Dislikes = -999
            };

            MovieDb noUpdate = _repo.UpdateMovie(badMovieDb);

            Assert.IsNull(noUpdate);
        }

        [Test]
        public void DeleteMovie()
        {
            MovieDb test = new MovieDb
            {
                MovieTitle = "Test Insert"
            };

            MovieDb created = _repo.CreateMovie(test);
            IEnumerable<MovieDb> original = _repo.ReadAllMovies();

            bool deleted = _repo.DeleteMovie(created.MovieId);
            IEnumerable<MovieDb> afterDel = _repo.ReadAllMovies();
            
            Assert.AreEqual(4, original.Count());
            Assert.IsTrue(deleted);
            Assert.AreEqual(3, afterDel.Count());
        }

        [Test]
        public void DeleteFail()
        {
            bool deleteFail = _repo.DeleteMovie(Int32.MinValue);
            
            Assert.IsFalse(deleteFail);
        }
    }
}