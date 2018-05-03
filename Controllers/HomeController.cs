using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private WeddingContext _context;
 
        public HomeController(WeddingContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel user)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User myUser = _context.Users.SingleOrDefault(User => User.Email == user.Email);

            if(myUser != null) {
                Console.WriteLine("***********Found User************");
                Console.WriteLine(hasher.VerifyHashedPassword(myUser, myUser.Password, user.Password));
                if(hasher.VerifyHashedPassword(myUser, myUser.Password, user.Password) == PasswordVerificationResult.Success)
                {
                    Console.WriteLine("***************Verified Password*************");
                    HttpContext.Session.SetInt32("id", myUser.Id);
                }
            }
            return RedirectToAction("Index", "Wedding");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel user)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                newUser.Password = hasher.HashPassword(newUser, user.Password);

                _context.Add(newUser);
                _context.SaveChanges();

                User myUser = _context.Users.SingleOrDefault(User => User.Email == user.Email);

                HttpContext.Session.SetInt32("id", myUser.Id);
                return RedirectToAction("Index", "Wedding");
            }
            else
            {
                Console.WriteLine("******* VALIDATION FAILED*******");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
