using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using community_assis_2017.Models; // reference to model(project name)

namespace community_assis_2017.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();//CommunityAssist2017Entities is a name of the model(your database name)
            return View(db.GrantTypes.ToList());
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