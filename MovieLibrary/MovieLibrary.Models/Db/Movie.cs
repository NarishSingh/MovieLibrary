using System;

namespace MovieLibrary.Models.Db
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int ImdbId { get; set; }
        public string Title { get; set; }
        public Director Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Liked { get; set; }
        public string? Description { get; set; }
        public string? YoutubeTrailerKey { get; set; }
        public Genre Genre { get; set; }
    }
}