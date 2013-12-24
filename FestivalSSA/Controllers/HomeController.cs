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
        [AllowAnonymous]
        public ActionResult Index(string stageid,string dateid)
        {
            var model = LineUpRepository.GetLineUp(stageid,dateid);
            ViewBag.StageID = new SelectList(StageRepository.GetStages(), "ID", "Name");
            ViewBag.DateID = new SelectList(FestivaldagRepository.GetFestivaldagen(), "ID", "Date");
            return View(model);
        }
        [Authorize]
        public ActionResult Insert()
        {
            ViewBag.TypeID = new SelectList(TickettypeRepository.GetTypes(), "ID", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Ticketholder reservatie)
        {
            ViewBag.TypeID = new SelectList(TickettypeRepository.GetTypes(), "ID", "Name");
            if (ModelState.IsValid)
            {
                TicketholderRepository.InsertReservatie(reservatie);
                return View("Ticket", reservatie);
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Reservaties()
        {
            var model = TicketholderRepository.GetReservaties();
            return View(model);
        }

        [Authorize(Roles="Admin")]
        public ActionResult Tickettypes()
        {
            var model = TickettypeRepository.GetTypes();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var model = BandRepository.FindById(id);
            return View(model);
        }
    }
}
