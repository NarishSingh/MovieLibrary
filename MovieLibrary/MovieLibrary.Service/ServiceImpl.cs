using System.Collections.Generic;
using System.Threading.Tasks;
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
        private const string ImagePath = "https://image.tmdb.org/t/p/w500"; //default 500px width

        public ServiceImpl()
        {
            _apiDao = new MovieApiImpl();
            _repoDao = new MovieRepoImpl();
        }

        public async Task<IEnumerable<MovieShortItem>> SearchNowPlaying()
        {
            return await _apiDao.SearchNowPlaying();
        }

        public async Task<IEnumerable<MovieShortItem>> SearchByTitle(string title)
        {
            return await _apiDao.SearchByTitle(title);
        }

        public async Task<Movie> GetMovieById(int id)
        {
            //get from api, read from db by title (id's will be different)
            MovieDetailedItem fromApi = await _apiDao.SearchMovieById(id);
            if (fromApi == null) return null; //if api call fails, movie doesn't exist
            
            //if not present in db, RepoId is null and likes/dislikes defaults to 0
            MovieDb fromRepo = _repoDao.ReadMovieByTitle(fromApi.Title);
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

        public Movie PersistLikeDislike(Movie m)
        {
            //check if movie exists in db
            if (m.RepoId != null)
            {
                MovieDb update = new MovieDb
                {
                    MovieId = m.RepoId.GetValueOrDefault(), //will never be null due to check, but required to stop error
                    MovieTitle = m.Title,
                    Likes = m.Likes,
                    Dislikes = m.Dislikes
                };

                return _repoDao.UpdateMovie(update) != null ? m : null;
            }

            //else, create new entry
            MovieDb newEntry = _repoDao.CreateMovie(
                new MovieDb
                {
                    MovieTitle = m.Title,
                    Likes = m.Likes,
                    Dislikes = m.Dislikes
                }
            );
            m.RepoId = newEntry.MovieId; //set RepoId as it was previously null

            return m;
        }
    }
}