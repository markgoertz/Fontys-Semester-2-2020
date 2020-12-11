using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Collections;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Converters;
using Fontys_S2_Project___Car_to_go.Models;
using Logic_interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{

    public class UserController : Controller 
    {
        private readonly IUserCollection _user;
        private readonly IUser userlogic;
        private List<UserViewModel> UVM;
        public UserController(IUserCollection usercollection, IUser userrichmodel)
        {
            _user = usercollection;
            userlogic = userrichmodel;
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


            if (ModelState.IsValid)
            {
                string LoginStatus = userlogic.ValidateLogin(user);

                if (LoginStatus == "Success")
                {
                    var all = _user.GetUsers();
                    UVM = new List<UserViewModel>();
                    //If the ID isn't equil to Null-value, the if-statement is executed.
                    if (user.Email != null)
                    {
                        //Here it count with int 'i' and it keeps counting 'til the max value of all is counted.
                        for (int i = 0; i < all.Count; i++)
                        {
                            //When ID is equil to all; the program will 'copy' all values of Vehicleviewmodel and add it to VVM.
                            if (user.Email == all[i].Email)
                            {
                                UVM.Add(new UserViewModel
                                {
                                    ID = all[i].ID,
                                    Firstname = all[i].Firstname,
                                    Lastname = all[i].Lastname,
                                    Email = all[i].Email,
                                    Adres = all[i].Adres,
                                    Housenumber = all[i].Housenumber,
                                    Password = all[i].Password,
                                    Postalcode = all[i].Postalcode,
                                    Role = all[i].Role,

                                });

                                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Email, user.Email),
                                    new Claim(ClaimTypes.Role, all[i].Role),
                                };
                                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                                await HttpContext.SignInAsync(principal);
                                TempData["LoggedIn"] = "You have logged in with your personal account.";
                                return RedirectToAction("Index", "Home");

                            }
                        }
                    }
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            return View();
        }



        [HttpGet]
        public IActionResult CreateAccount()
        {
            var UVM = new UserViewModel();
            return View(UVM);
        }

        [HttpPost]
        public ActionResult CreateAccount(UserViewModel user)
        {
            var converted = ViewModelConverter.ConvertUserViewModelToModel(user);
            var check = userlogic.CheckDoubleEmails(converted);
            if (check == true)
            {
                 TempData["DoubleEmails"] = "The specified email is already known in our system.";
                 return View();
            }
            else
            {
                _user.Create(converted);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            TempData["UserLogout"] = "You have logged out!";
            await HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin", "User");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Update()
        {
            var all = _user.GetUsers();
            var items = new UserViewModel();
            foreach (var user in all)
            {
                if (User.HasClaim(ClaimTypes.Email,user.Email))
                {
                    items = new UserViewModel()
                    {
                        ID = user.ID,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Adres = user.Adres,
                        Email = user.Email,
                        Housenumber = user.Housenumber,
                        Password = user.Password,
                        Postalcode = user.Postalcode,
                        Role = user.Role
                      
                    };

                }
            }
            return View(items);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Update(UserViewModel model)
        {
            userlogic.Edit(ViewModelConverter.ConvertUserViewModelToModel(model));
            TempData["Update"] = "The records has been changed from the system!";
            return RedirectToAction("Index","Home");
        }

        [Authorize(Roles = "User")]
        public IActionResult Delete(int ID)
        {
            userlogic.Delete(ID);
            TempData["Delete"] = "The records are deleted from the system!";
            return RedirectToAction("Logout","User");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
