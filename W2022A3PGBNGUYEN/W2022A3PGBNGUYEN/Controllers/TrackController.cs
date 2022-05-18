using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A3PGBNGUYEN.Models;

namespace W2022A3PGBNGUYEN.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        private Manager m = new Manager();

        public ActionResult Index()
        {
            var myTracks = m.TrackGetAllWithDetail();
            return View(myTracks);
        }
        public ActionResult Details(int? id)
        {
            var myTrack = m.TrackGetById(id.GetValueOrDefault());
                return View(myTrack);
        }
        public ActionResult Create()
        {
            var form = new TrackAddFormViewModel();

            


            form.AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title", 156);
            form.MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name", 1);
            return View(form);
        }

        [HttpPost]
        public ActionResult Create(TrackAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.TrackId });
            }
        }
    }
}