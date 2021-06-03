using System.Collections.Generic;
using MovieLibrary.Data;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Service;

namespace MovieLibrary.Service
{
    public class ServiceImpl : IService
    {
        private IMovieApi _apiDao;
        private IMovieRepo _repoDao;

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
            //get from api
            MovieDetailedItem fromApi = _apiDao.SearchMovieById(id);

            //read from db by title (id's will be different), if not present, likes/dislikes set to 0
            
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