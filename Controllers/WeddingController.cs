using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {

        private WeddingContext _context;
 
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }

        private IActionResult ValidateUser()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                return null;
            }
            else
            {
                return RedirectToAction("Index", "Home");
                
            }
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                User myUser = _context.Users.SingleOrDefault(User => User.Id == HttpContext.Session.GetInt32("id"));
                ViewBag.Weddings = _context.Weddings.Include(w => w.GuestLists).ToList();

                ViewBag.User = myUser;
                ViewBag.Error = TempData["error"];
                return View();
            } else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Route("wedding")]
        public IActionResult NewWedding()
        {
            ValidateUser();
            return View();
        }

        [HttpPost]
        [Route("wedding/save")]
        public IActionResult SaveWedding(WeddingViewModel wedding)
        {

            if(ModelState.IsValid)
            {
                Wedding myWedding = new Wedding
                {
                    UserId = (int)HttpContext.Session.GetInt32("id"),
                    WedderOne = wedding.WedderOne,
                    WedderTwo = wedding.WedderTwo,
                    WeddingDate = wedding.WeddingDate,
                    Address = wedding.WeddingAddress,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Add(myWedding);
                _context.SaveChanges();
            }
            else
            {
                TempData["error"] = "Validation Failed";
            }
            return RedirectToAction("Index", "Wedding");
        }

        [HttpGet]
        [Route("wedding/{wedding_id}/rsvp")]
        public IActionResult RSVP(int wedding_id)
        {
            GuestList newGuest = new GuestList
            {
                UserId = (int)HttpContext.Session.GetInt32("id"),
                WeddingId = wedding_id
            };

            _context.Add(newGuest);
            _context.SaveChanges();

            return RedirectToAction("Index", "Wedding");
        }

        [HttpGet]
        [Route("wedding/{wedding_id}/unrsvp")]
        public IActionResult UnRSVP(int wedding_id)
        {
            GuestList remove =  _context.GuestLists
                            .SingleOrDefault(Guest => Guest.WeddingId == wedding_id && 
                                                 Guest.UserId == (int)HttpContext.Session.GetInt32("id"));

            _context.Remove(remove);
            _context.SaveChanges();


            return RedirectToAction("Index", "Wedding");
        }
    }
}