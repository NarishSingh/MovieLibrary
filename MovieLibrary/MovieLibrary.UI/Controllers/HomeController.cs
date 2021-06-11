using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MovieLibrary.Models.API;
using MovieLibrary.Models.Service;
using MovieLibrary.Service;
using MovieLibrary.UI.Models;

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

        /// <summary>
        /// GET - Add a like to a movie
        /// </summary>
        /// <param name="id">int for the movie's id from the API</param>
        /// <returns>Redirect to the Details GET action</returns>
        [HttpGet]
        public async Task<ActionResult> AddLike(int id)
        {
            Movie m = await _service.GetMovieById(id);
            m.Likes++;
            Movie persisted = _service.PersistLikeDislike(m);

            return RedirectToAction("Details", "Home", new {id = persisted.ApiId});
        }

        /// <summary>
        /// GET - Add a dislike to a movie
        /// </summary>
        /// <param name="id">int for the movie's id from the API</param>
        /// <returns>Redirect to the Details GET action</returns>
        [HttpGet]
        public async Task<ActionResult> AddDislike(int id)
        {
            Movie m = await _service.GetMovieById(id);
            m.Dislikes++;
            Movie persisted = _service.PersistLikeDislike(m);

            return RedirectToAction("Details", "Home", new {id = persisted.ApiId});
        }
    }
}