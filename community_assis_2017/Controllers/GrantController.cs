using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using community_assis_2017.Models;

namespace community_assis_2017.Controllers
{
    public class GrantController : Controller
    {
        // GET: Grant
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in to create a grant";
                return RedirectToAction("Result", msg);
            }
            ViewBag.GrantList = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="GrantTypeKey, GrantApplicationReason, GrantApplicationRequestAmount")]GrantApplication g)
        {
            try
            {
                g.PersonKey = (int)Session["PersonKey"];
                g.GrantAppicationDate = DateTime.Now;
                g.GrantApplicationStatusKey = 1;
                db.GrantApplications.Add(g);
                db.SaveChanges();
                Message m = new Message();
                m.MessageText = "Thank you for your grant Request";
                return RedirectToAction("Result", m);
            }
            catch (Exception e)
            {
                Message m = new Message();
                m.MessageText = e.Message;
                return RedirectToAction("Result", m);
            }
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

    }
}