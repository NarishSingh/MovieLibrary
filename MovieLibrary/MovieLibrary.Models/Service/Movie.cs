using System;
using System.Collections.Generic;

namespace MovieLibrary.Models.Service
{
    /// <summary>
    /// Combines data from the db dto and detailed api dto into one model
    /// </summary>
    public class Movie
    {
        public int? RepoId { get; set; } //id saved as in repo, null when entry of movie is not in db
        public int ApiId { get; set; } //id from MovieDb API
        public string Title { get; set; }
        public IEnumerable<string> Directors { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public string? PosterPath { get; set; }
        public IEnumerable<string> TrailerLinks { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}