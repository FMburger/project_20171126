using demo_2017._11._26.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo_2017._11._26.Controllers
{
    public class HomeController : Controller
    {
        private articleContext db = new articleContext();
        public ActionResult Index()
        {
            return View(db.articles.ToList());
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
    }
}