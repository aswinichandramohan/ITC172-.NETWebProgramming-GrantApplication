using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using community_assis_2017.Models;

namespace community_assis_2017.Controllers
{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, Password")]LoginClass lc)
        {
            int results = db.usp_Login(lc.UserName, lc.Password);
            int revKey = 0;
            Message msg = new Message();
            if (results != -1)
            {
                var pKey = (from person in db.People
                            where person.PersonEmail.Equals(lc.UserName)
                            select person.PersonKey).FirstOrDefault();
                revKey = (int)pKey;  //casting pKey as var
                Session["PersonKey"] = revKey; //session level variable that go to the server

               
                msg.MessageText = "Welcome, " + lc.UserName;

            }

            else
            {
                msg.MessageText = "Invalid Login";
            }
            return View("Result", msg);
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

    }

}