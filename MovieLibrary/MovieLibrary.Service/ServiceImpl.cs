using System.Collections.Generic;
using MovieLibrary.Data;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Db;
using MovieLibrary.Models.Service;

namespace MovieLibrary.Service
{
    public class ServiceImpl : IService
    {
        private IMovieApi _apiDao;
        private IMovieRepo _repoDao;
        private const string ImagePath = "https://image.tmdb.org/t/p/w500/"; //default 500px width

        public ServiceImpl()
        {
            _apiDao = new MovieApiImpl();
            _repoDao = new MovieRepoImpl();
        }


        public IEnumerable<MovieShortItem> SearchNowPlaying()
        {
            return _apiDao.SearchNowPlaying();
        }

        public IEnumerable<MovieShortItem> SearchByTitle(string title)
        {
            return _apiDao.SearchByTitle(title);
        }

        public Movie GetMovieById(int id)
        {
            //get from api, read from db by title (id's will be different)
            MovieDetailedItem fromApi = _apiDao.SearchMovieById(id);
            MovieDb fromRepo = _repoDao.ReadMovieByTitle(fromApi.Title);

            // if not present, RepoId is null and likes/dislikes set to 0
            if (fromRepo == null)
            {
                return new Movie
                {
                    RepoId = null,
                    ApiId = fromApi.Id,
                    Title = fromApi.Title,
                    Directors = fromApi.Directors,
                    ReleaseDate = fromApi.ReleaseDate,
                    Description = fromApi.Description,
                    PosterPath = ImagePath + fromApi.PosterPath,
                    Likes = 0,
                    Dislikes = 0
                };
            }

            return new Movie
            {
                RepoId = fromRepo.MovieId,
                ApiId = fromApi.Id,
                Title = fromApi.Title,
                Directors = fromApi.Directors,
                ReleaseDate = fromApi.ReleaseDate,
                Description = fromApi.Description,
                PosterPath = ImagePath + fromApi.PosterPath,
                Likes = fromRepo.Likes,
                Dislikes = fromRepo.Dislikes
            };
        }

        public Movie LikeMovie(int id)
        {
            throw new System.NotImplementedException();
        }

        public Movie DislikeMovie(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}