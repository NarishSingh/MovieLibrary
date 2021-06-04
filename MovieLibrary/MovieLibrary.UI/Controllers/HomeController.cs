using System.Collections.Generic;
using System.Web.Mvc;
using MovieLibrary.Models.API;
using MovieLibrary.Service;

namespace MovieLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        private IService _service = new ServiceImpl();
        
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<MovieShortItem> model = _service.SearchNowPlaying();
            return View(model);
        }
    }
}