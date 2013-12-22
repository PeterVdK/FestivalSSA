using FestivalSSA.Models;
using FestivalSSA.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalSSA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string stageid,string dateid)
        {
            var model = LineUpRepository.GetLineUp(stageid,dateid);
            ViewBag.StageID = new SelectList(StageRepository.GetStages(), "ID", "Name");
            ViewBag.DateID = new SelectList(FestivaldagRepository.GetFestivaldagen(), "ID", "Date");
            return View(model);
        }

        public ActionResult Bestellen()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Details(int id)
        {
            var model = BandRepository.FindById(id);
            return View(model);
        }
    }
}
