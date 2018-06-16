using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using community_assis_2017.Models;

namespace community_assis_2017.Controllers
{
    public class DonationController : Controller
    {
        
        // GET: Donation
        public ActionResult Index()
        {
            if(Session["PersonKey"]==null)
            {
                //Message m = new Message("You must be logged in to donate");
                return RedirectToAction("Index","Login");
                //When you open the page, it will check whether this session exists. Session only exist if you logged in. 
                //...If session doesn't exist, it will redirect to result page.
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "DonationAmount")]Donation d)
        {
            d.DonationDate = DateTime.Now;
            d.DonationConfirmationCode = Guid.NewGuid();
            d.PersonKey = (int)Session["PersonKey"];
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            db.Donations.Add(d);
            db.SaveChanges();
            Message m = new Message("Thank you for the Donation!!");
            return View("Result", m);
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}