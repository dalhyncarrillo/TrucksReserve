﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;
using System.Web.Mvc;

using TrucksReserve.Instruments;

using BusinessLayer;
using BusinessLayer.BObjects;
using BusinessLayer.Classes;

using TrucksReserve.Models;
using ToolsLibrary;

namespace TrucksReserve.Controllers
{
    [Authorize] 
    [HandleError]
    public class AdminController : BaseController
    {
        /// <param name="StrSelectedTextID">Parameter name must be equal to the one in AdminModel</param>
        public ActionResult Index(string StrSelectedTextID)
        {
            //Fill in the texts, which can be modified

            int? selectedTextID = null;
            if (StrSelectedTextID.GetTrimmed().IsEmpty() == false)
            {
                int id = 0;
                if (int.TryParse(StrSelectedTextID.GetTrimmed(), out id) == false)
                {
                    UiTools.NewUiException(string.Format("Не можа да парсне SelectedTextID (string : '{0}') към инт.", StrSelectedTextID.GetTrimmed()));
                }
                else
                {
                    selectedTextID = id;
                }
            }

            return View(GetModel(selectedTextID));
        }

        [HttpPost]
        public ActionResult Index(AdminModel model)
        {
            if (ModelState.IsValid)
            {
                Texts.UpdateText(model.TextToUpdate.ID, model.TextToUpdate.Description);
            }

            int? selectedTextID = null;
            if (model.TextToUpdate != null) { selectedTextID = model.TextToUpdate.ID; }

            return View(GetModel(selectedTextID));
        }

        public AdminModel GetModel(int? typeID = null)
        {
            AdminModel adminModel = new AdminModel();

            BMainModel bModel = Main.GetData(LoadedPage.Admin , typeID: typeID, loadCategories: false);
            bModel.ExcIfNull();

            adminModel.TextToUpdate = bModel.TextToUpdate;
            if (bModel.TextsToEdit.AreThereItems() == true)
            {
                adminModel.TextsToEdit = new List<SelectListItem>();
                foreach (BBaseText bText in bModel.TextsToEdit)
                {
                    adminModel.TextsToEdit.Add(new SelectListItem()
                    {
                        Selected = (adminModel.TextToUpdate != null && bText.ID == adminModel.TextToUpdate.ID),
                        Text = bText.Name,
                        Value = bText.ID.ToString()
                    });
                }
            }

            return adminModel;
        }
    }
}
