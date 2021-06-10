using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MovieLibrary.Service;

namespace MovieLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        private IService _service = new ServiceImpl();

        /// <summary>
        /// GET - index page displaying titles currently playing
        /// </summary>
        /// <returns>View containing model with all currently screening movie titles</returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _service.SearchNowPlaying());
        }

        /// <summary>
        /// GET - search results page displaying titles matching search query
        /// </summary>
        /// <param name="query">string for search query</param>
        /// <returns>View containing titles for search results</returns>
        [HttpGet]
        public async Task<ActionResult> SearchTitle(string query)
        {
            return View(await _service.SearchByTitle(query));
        }

        /// <summary>
        /// GET - get details for a movie entry
        /// </summary>
        /// <param name="id">int for a valid movie id for MovieDb</param>
        /// <returns>View containing detailed movie info and like/dislike counts</returns>
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _service.GetMovieById(id));
        }
    }
}