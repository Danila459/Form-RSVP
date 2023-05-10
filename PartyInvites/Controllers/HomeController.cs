using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро" : "Доброго дня";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guest)
        {
            if (ModelState.IsValid)
            {
                guest.AddGuests(guest);
                return View("Thanks", guest);
            }
            else

                return View();
        }

        public ViewResult Guests()
        {
            Guests guests = new Guests();

            return View(guests.GetGuests());
            // return View();

        }


    }
}