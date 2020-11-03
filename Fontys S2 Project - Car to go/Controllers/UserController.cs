using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{
    public class UserController : Controller
    {
        private User _user;
        private readonly User _coll;
        public UserController()
        {
            _coll = new User();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string ReturnUrl)
        {

            if ((username == "Admin") && (password == "Admin"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Secured" : ReturnUrl);
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult CreateAccount()
        {
            var UVM = new UserViewModel();
            return View(UVM);
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            _coll.Create(user);
            return RedirectToAction("Index");

        }

    }
}
