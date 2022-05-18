using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A5PGBNGUYEN.Controllers
{
    public class TrackController : Controller
    {
        public Manager m = new Manager();
        // GET: Track
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            var tracks = m.TrackGetAll();

            return View(tracks);
        }

        // GET: Track/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());
            return View(track);
        }

        // GET: Track/Create
        [Authorize(Roles = "Clerk")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var trackToDelete = m.TrackGetById(id.GetValueOrDefault());

            if (trackToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(trackToDelete);
            }
        }

        // POST: Track/Delete/5
        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                m.TrackDelete(id.GetValueOrDefault());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
