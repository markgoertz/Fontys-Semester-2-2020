using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fontys_S2_Project___Car_to_go.Converters;
using Fontys_S2_Project___Car_to_go.Models;
using Logic_interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fontys_S2_Project___Car_to_go.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminUsers : Controller
    {
        private readonly IUserCollection _coll;
        private readonly IUser _user;
        List<UserViewModel> userviews = new List<UserViewModel>();

        public AdminUsers(IUserCollection collection, IUser user)
        {
            _coll = collection;
            _user = user;
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
        public IActionResult Create(UserViewModel usercheck)
        {
            var convertedmodel = ViewModelConverter.ConvertUserViewModelToModel(usercheck);
            var check = _user.CheckDoubleEmails(convertedmodel);

            if (check == true)
            {
                TempData["DoubleEmails"] = "The specified email is already known in our system.";
                return View();
            }
            else
            {
                _coll.Create(convertedmodel);
            }

            return RedirectToAction("Index");
        }



        /* UPDATE ------------------------------------------- UPDATE ------------------------------------------------------ UPDATE --------------------------------------------------- UPDATE ------------------------------------ UPDATE*/

        [HttpGet]
        public ActionResult Update(int ID)
        {
            var all = _coll.GetUsers();
            

            foreach (var user in all)
            {
                //when the ID's are equal. This ID's will be chosen, and all the information that carries with the ID will be writen.
                if (ID == user.ID)
                {
                    var uservm = new UserViewModel()
                    {
                        ID = user.ID,
                        Email = user.Email,
                        Adres = user.Adres,
                        Firstname = user.Firstname,
                        Housenumber = user.Housenumber,
                        Lastname = user.Lastname,
                        Password = user.Password,
                        Postalcode = user.Postalcode,
                        Role = user.Role
                    };

                    return View(uservm);
                }
            } 
            return View();

        }

        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            var converted = ViewModelConverter.ConvertUserViewModelToModel(model);
            _user.Edit(converted);

            TempData["Update"] = "The records has been changed from the system!";
            return RedirectToAction("Index");
        }


/* DELETE ------------------------------------------- DELETE ------------------------------------------------------ DELETE --------------------------------------------------- DELETE ------------------------------------ DELETE*/

        public IActionResult Delete(int ID)
        {
            _user.Delete(ID);
            TempData["Delete"] = "The records has been deleted from the system!";
            return RedirectToAction("Index");
        }
    }
}


