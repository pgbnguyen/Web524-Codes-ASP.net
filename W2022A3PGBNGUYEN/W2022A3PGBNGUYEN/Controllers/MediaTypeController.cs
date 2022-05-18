using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A3PGBNGUYEN.Controllers
{
    public class MediaTypeController : Controller
    {
        // GET: MediaType
        private Manager m = new Manager();

        public ActionResult Index()
        {
            var myMediaTypes = m.MediaTypeGetAll();
            return View(myMediaTypes);
        }
    }
}