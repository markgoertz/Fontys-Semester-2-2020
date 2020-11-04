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
        
        private readonly User _user;
        public UserController()
        {
            _user = new User();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] User user)
        {
            ModelState.Remove("ID");
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Postalcode");
            ModelState.Remove("Housenumber");
            ModelState.Remove("Adres");
            ModelState.Remove("Role");

            if (ModelState.IsValid)
            {
                string LoginStatus = _user.ValidateLogin(user);

                if (LoginStatus == "Success")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
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
            _user.Create(user);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin", "User");
        }

    }
}
