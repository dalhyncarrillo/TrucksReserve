﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Web.Mvc;
using System.Web.Security;

using BusinessLayer.Classes;

namespace TrucksReserve.Controllers
{
    [Authorize] // Permits access to pages for not signed in users, if there is no [AllowAnonymous] attribute specified for them (pages)(not tested)
    [HandleError]
    public class AccountController : BaseController
    {
        [HttpGet]
        [AllowAnonymous] //The page can be accessed by not signed in users
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(Models.LoginModel user)
        {
            if (ModelState.IsValid)
            {
                if (Accounts.IsValidUser(user.UserName, user.Password) == true)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Невалиден потребител и/или парола.");
                }
            }

            return View(user);
        }

    }
}
