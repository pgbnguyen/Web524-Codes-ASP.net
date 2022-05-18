using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6PGBNGUYEN.Models;

namespace W2022A6PGBNGUYEN.Controllers
{
    public class AlbumController : Controller
    {
        Manager m = new Manager();

        // GET: Album
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            
            return View(m.AlbumGetAll());
        }

        // GET: Album/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var obj = m.AlbumGetById(id.GetValueOrDefault());
            if (obj == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(obj);
            }

        }
        //GET
        [Authorize(Roles = "Clerk"), Route("albums/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());

            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                var trackAdd = new TrackAddFormViewModels();
               
                trackAdd.AlbumId = album.Id;
                trackAdd.AlbumName = album.Name;
                trackAdd.Composers = string.Join(",", album.ArtistNames.ToArray());
                trackAdd.TrackGenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(trackAdd);
            }
        }
        //POST
        [Authorize(Roles = "Clerk"), Route("albums/{id}/addtrack")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTrack(TrackAddViewModels track)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(track);
                }

                // TODO: Add insert logic here
                var addedTrack = m.TrackAdd(track);

                if (addedTrack == null)
                {
                    return View(track);
                }
                else
                {
                    return RedirectToAction("details", "track", new { id = addedTrack.Id });
                }
            }
            catch
            {
                return View();
            }
        }
        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
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

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
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

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
