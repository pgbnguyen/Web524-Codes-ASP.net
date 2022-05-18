using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6PGBNGUYEN.Models;

namespace W2022A6PGBNGUYEN.Controllers
{
    public class TrackController : Controller
    {
        public Manager m = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            var tracks = m.TrackGetAll();

            return View(tracks);
        }


        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
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

        // GET: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<TrackWithDetailViewModels, TrackEditFormViewModels>(track);
                return View(form);
            }
        }

        // POST: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditViewModels newTrack)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Edit", new { id = newTrack.Id });
                }
                else if (id.GetValueOrDefault() != newTrack.Id)
                {
                    return RedirectToAction("Index");
                }

                var editedTrack = m.TrackEdit(newTrack);

                if (editedTrack == null)
                {
                    return RedirectToAction("Edit", new { id = newTrack.Id });
                }
                else
                {
                    return RedirectToAction("Details", new { id = newTrack.Id });
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Delete/5
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

        // POST: Tracks/Delete/5
        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
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
