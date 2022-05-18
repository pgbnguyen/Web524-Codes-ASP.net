using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A5PGBNGUYEN.Models;

namespace W2022A5PGBNGUYEN.Controllers
{
    public class ArtistController : Controller
    {
        Manager m = new Manager();
        // GET: Artist
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            var objects = m.ArtistGetAll();
            return View(objects);
        }

        // GET: Artist/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int id)
        {
            var artist = m.ArtistGetById(id);
            return View(artist);
        }

        // GET: Artist/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var artist = new ArtistAddFormViewModels();

            artist.Executive = User.Identity.Name;
            artist.ArtistGenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(artist);
        }

        // POST: Artist/Create
        [Authorize(Roles = "Executive")]
        [HttpPost]
        public ActionResult Create(ArtistAddViewModels newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.ArtistId });
            }
        }
        [Authorize(Roles = "Coordinator"), Route("artists/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetById(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var albumAdd = new AlbumAddFormViewModels();
                albumAdd.ArtistId = artist.ArtistId;
                albumAdd.ArtistName = artist.Name;
                albumAdd.AlbumGenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                var selectedArtists = new List<int> { artist.ArtistId };
                albumAdd.ArtistList = new MultiSelectList(m.ArtistGetAll(), "ArtistId", "Name", selectedArtists);
                albumAdd.TrackList = new MultiSelectList(m.TrackGetAllByArtistId(artist.ArtistId), "TrackId", "Name");
                return View(albumAdd);
            }
        }
        // POST: Artists/Create
        //Once user input on the page, this function will be triggered.
        [Authorize(Roles = "Coordinator"), Route("artists/{id}/addalbum")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModels album)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(album);
                }

                var addedAlbum = m.AlbumAdd(album);

                if (addedAlbum == null)
                {
                    return View(album);
                }
                else
                {
                    return RedirectToAction("Details", "Albums", new { id = addedAlbum.AlbumId });
                }

            }
            catch
            {
                return View();
            }
        }
        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artist/Edit/5
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

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artist/Delete/5
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
