using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Event.Models;

namespace Event.Controllers
{
    public class HomeController : Controller
    {
        
        DbModel db = new DbModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        {

//retrieving data from database
            var events = db.EventDetails.ToList();

            

            return View(events);
        }
        public ActionResult ViewEvent(string Event_name)
        {
            ViewBag.Event_name = Event_name;
            return View();
        }
    }
}