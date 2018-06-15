using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using community_assis_2017.Models;

namespace community_assis_2017.Controllers
{
    public class RegisterController : Controller
    {
        private CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(
            [Bind(Include = "LastName, FirstName, Email, Phone, PlainPassword, Apartment, Street, City, State, Zipcode")]NewPerson person)
        // Bind going to bind all fields from the stored procedure to new instants of class person
        {
            
            Message m = new Message();
            int result = db.usp_Register(person.LastName,
            person.FirstName, person.Email, person.PlainPassword, 
            person.Apartment, person.Street, 
            person.City, person.State, person.Zipcode, person.Phone);
           

            if (result != -1)
            {
                m.MessageText = "Welcome, " + person.FirstName;
            }

            else
            {
                m.MessageText = "Something Went Error";

            }

            return View("Result", m);
        }

public ActionResult Result(Message m)
        {
            return View(m);
        }




    }
}