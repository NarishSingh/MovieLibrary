using System.Configuration;

namespace MovieLibrary.Data
{
    public class Settings
    {
        private static string _connString;
        
        /// <summary>
        /// Get the connection string from project's respective .config file
        /// </summary>
        /// <returns>string for connection string to db</returns>
        public static string GetConnString()
        {
            if (string.IsNullOrEmpty(_connString))
            {
                _connString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
            }

            return _connString;
        }
    }
}