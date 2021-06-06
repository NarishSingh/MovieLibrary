using System;
using System.Web.Mvc;
using MovieLibrary.Service;
using MovieLibrary.UI.Models;

namespace MovieLibrary.UI.Controllers
{
    public class SearchController : Controller
    {
        private IService _service = new ServiceImpl();

        [HttpPost]
        public ActionResult Search(SearchRequestVM model)
        {
            throw new NotSupportedException();
        }
    }
}