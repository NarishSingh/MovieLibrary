using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;

namespace MovieLibrary.Test
{
    [TestFixture]
    public class MovieRepoTests
    {
        [SetUp]
        public void Init()
        {
            //reset db to a known state for each test
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieLibrary"]
                    .ConnectionString;
                
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