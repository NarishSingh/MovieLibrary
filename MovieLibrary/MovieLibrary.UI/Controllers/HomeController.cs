using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MovieLibrary.Models.API;
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
            IEnumerable<MovieShortItem> model = _service.SearchNowPlaying();
            return View(model);
        }

        
    }
}