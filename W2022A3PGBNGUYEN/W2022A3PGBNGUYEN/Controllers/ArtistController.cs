using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A3PGBNGUYEN.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        private Manager m = new Manager();

        public ActionResult Index()
        {
            var myArtists = m.ArtistGetAll();
            return View(myArtists);
        }
    }
}