using System;
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
        /// <returns>ActionResult for Index View, with a model containing a IEnumerable of MovieShortItem's</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.SearchNowPlaying());
        }

        [HttpGet]
        public ActionResult Search(string query)
        {
            //TODO validate query with regex, look up form validation on bootstrap
            return View(_service.SearchByTitle(query));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            throw new NotSupportedException();
        }
    }
}