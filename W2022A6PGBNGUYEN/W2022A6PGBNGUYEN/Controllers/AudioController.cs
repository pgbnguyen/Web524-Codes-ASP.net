using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6PGBNGUYEN.Controllers
{
    public class AudioController : Controller
    {
        Manager m = new Manager();
        // GET: Audio/Details/5
        [Route("audio/{id}")]
        public ActionResult Details(int? id)
        {
            var a = m.TrackAudioGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {

                if (a.AudioContentType != null)
                {
                    return File(a.Audio, a.AudioContentType);
                }

                return Content("No audio");
            }

        }
        // GET: Audio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Audio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Audio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audio/Create
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

        // GET: Audio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Audio/Edit/5
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

        // GET: Audio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Audio/Delete/5
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
