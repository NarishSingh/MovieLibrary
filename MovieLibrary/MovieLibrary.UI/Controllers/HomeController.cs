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
            return View(await _service.SearchByTitle(query)); //todo this is failing on "spider man" -> [JsonSerializationException: Error converting value {null} to type 'System.DateTime'. Path 'results[9].release_date', line 1, position 6542.]
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            throw new NotSupportedException();
        }
    }
}