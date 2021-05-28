using System.Data;
using System.Data.SqlClient;
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
            
            Assert.NotNull(created);
            Assert.AreEqual(4, created.MovieId);
            Assert.AreEqual("Test Insert", created.MovieTitle);
            Assert.AreEqual(0, created.Likes);
            Assert.AreEqual(0, created.Dislikes);
        }
    }
}