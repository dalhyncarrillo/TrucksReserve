﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Web.Mvc;

namespace TrucksReserve.Controllers
{
    /// <summary>
    /// Handles 404 and 500 errors
    /// http://www.deanhume.com/Home/BlogPost/custom-error-pages-in-mvc/4 
    /// </summary>
    public class ErrorController : BaseController
    {
        // Return the 404 not found page 
        public ActionResult Error404()
        {
            return RedirectToAction("ThrowException", "Base");
        }

        // Return the 500 not found page 
        public ActionResult Error500()
        {
            return RedirectToAction("ThrowException", "Base");
        }
    }
}
