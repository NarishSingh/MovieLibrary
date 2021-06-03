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
            throw new System.NotImplementedException();
        }

        public IEnumerable<MovieShortItem> SearchByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new System.NotImplementedException();
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