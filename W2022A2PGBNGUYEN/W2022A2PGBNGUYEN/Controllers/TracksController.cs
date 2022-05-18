using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A2PGBNGUYEN.Controllers
{
    public class TracksController : Controller
    {
        // GET: Tracks
        private Manager m = new Manager();

        public ActionResult Index()
        {
            var myTracks = m.TrackGetAll();
            return View(myTracks);
        }
        public ActionResult RockAndMetal()
        {
            var myTracks = m.TrackGetAllRockMetal();
            return View("Index", myTracks);
        }
        public ActionResult TylerAndVallance()
        {
            var myTracks = m.TrackGetAllTylerVallance();
            return View("Index", myTracks);
        }
        public ActionResult LongestTracks()
        {
            var myTracks = m.TrackGetAllTop50Longest();
            return View("Index", myTracks);
        }
        public ActionResult SmallestTracks()
        {
            var myTracks = m.TrackGetAllTop50Smallest();
            return View("Index", myTracks);
        }
    }
}