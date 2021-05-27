using System;

namespace MovieLibrary.Models.Db
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}