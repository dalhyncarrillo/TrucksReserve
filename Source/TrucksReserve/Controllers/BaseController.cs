﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Web.Mvc;

using System.Web.Security;

namespace TrucksReserve.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        [HandleError(View = "Error")]
        public ActionResult ThrowException()
        {
            throw new ApplicationException();
        }

        public ActionResult Logout()
        {
            if (Request.IsAuthenticated == true)
            {
                FormsAuthentication.SignOut();
            }
            
            return RedirectToAction("Index", "Main");
        }
    }
}
