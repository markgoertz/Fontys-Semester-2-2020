using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Collections;
using BLL.Models;
using Fontys_S2_Project___Car_to_go.Converters;
using Fontys_S2_Project___Car_to_go.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminUsers : Controller
    {
        private readonly UserCollection _coll;
        private readonly User user;
        List<UserViewModel> userviews = new List<UserViewModel>();

        public AdminUsers()
        {
            _coll = new UserCollection();
            user = new User();
        }

        /* INDEX ------------------------------------------- INDEX ------------------------------------------------------ INDEX --------------------------------------------------- INDEX ------------------------------------ INDEX*/

        public IActionResult Index()
        {
            var all = _coll.GetUsers();
            userviews = new List<UserViewModel>();

            
            foreach (var user in all)
                
            {
                var viewmodel = ViewModelConverter.ConvertModelToUserViewModel(user);
                userviews.Add(viewmodel);
            }
            return View(userviews);
        }

        /* CREATE ------------------------------------------- CREATE ------------------------------------------------------ CREATE --------------------------------------------------- CREATE ------------------------------------ CREATE*/

        [HttpGet]
        public ActionResult Create()
        {
            var VVM = new UserViewModel();
            return View(VVM);
        }

        [HttpPost]
        public IActionResult Create(User usercheck)
        {
            var check = user.CheckDoubleEmails(usercheck);
            if (check == true)
            {
                TempData["DoubleEmails"] = "The specified email is already known in our system.";
                return View();
            }
            else
            {
                _coll.Create(user);
            }
            return RedirectToAction("Index");
        }
    

        
        /* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/

        [HttpGet]
        public ActionResult Update(int ID)
        {
            var all = _coll.GetUsers();
            var items = new UserViewModel();
            foreach (var user in all)
            {
                if (ID == user.ID)
                {
                    items = new UserViewModel()
                    {
                        ID = user.ID, Firstname = user.Firstname, Lastname = user.Lastname, Adres = user.Adres, Email = user.Email, Housenumber = user.Housenumber, Password = user.Password, Postalcode = user.Postalcode, Role = user.Role
                    };

                }
            }
            return View(items);
        }

        [HttpPost]
        public ActionResult Update(User model)
        {
            user.Edit(model);
            TempData["Update"] = "The records has been changed from the system!";
            return RedirectToAction("Index");
        }


        /* DELETE ------------------------------------------- DELETE ------------------------------------------------------ DELETE --------------------------------------------------- DELETE ------------------------------------ DELETE*/

        public IActionResult Delete(int ID)
        {
            user.Delete(ID);
            TempData["Delete"] = "The records has been deleted from the system!";
            return RedirectToAction("Index");
        }
    }
}


