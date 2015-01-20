﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;
using System.Web.Mvc;

using BusinessLayer.BObjects;

namespace TrucksReserve.Models
{
    public class AdminModel
    {
        /// <summary>
        /// The name must be equal to that in MainController.Admin
        /// </summary>
        public string StrSelectedTextID { get; set; }
        public List<SelectListItem> TextsToEdit { get; set; }
        public BText TextToUpdate { get; set; }

    }
}