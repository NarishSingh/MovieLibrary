using System.Data;
using System.Data.SqlClient;
using MovieLibrary.Data;
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
    }
}