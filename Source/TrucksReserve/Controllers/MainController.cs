﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Web.Mvc;

using System.Web.Helpers;

using TrucksReserve.Models;

using BusinessLayer;
using BusinessLayer.BObjects;
using BusinessLayer.Classes;

using ToolsLibrary;

namespace TrucksReserve.Controllers
{
    [HandleError]
    public class MainController : BaseController
    {
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(GetModel(LoadedPage.AboutUs, isAjaxRequest : true));
            }

            return View(GetModel(LoadedPage.AboutUs));
        }

        public ActionResult Category(int? id = null)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(GetModel(LoadedPage.Categories, typeID: id, isAjaxRequest: true));
            }

            return View(GetModel(LoadedPage.Categories, id)); ;
        }

        public ActionResult Promotions()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(GetModel(LoadedPage.Promotions, isAjaxRequest: true));
            }

            return View(GetModel(LoadedPage.Promotions));
        }

        public ActionResult Firms()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(GetModel(LoadedPage.Firms, isAjaxRequest: true));
            }

            return View(GetModel(LoadedPage.Firms));
        }

        public ActionResult Services()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(GetModel(LoadedPage.Services, isAjaxRequest: true));
            }

            return View(GetModel(LoadedPage.Services));
        }

        public ActionResult ContactUs(bool mailSent = false)
        {
            MainModel viewModel = GetModel(LoadedPage.ContactUs, isAjaxRequest: (Request.IsAjaxRequest()));

            if (Request.IsAjaxRequest())
            {
                return PartialView(viewModel);
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult ContactUs(MainModel model)
        {
           string opResult = string.Empty;

            if (ModelState.IsValid)
            {
                Mail.SendMessageToSite(model.MailToSent.PersonEmail, model.MailToSent.Message);
                ModelState.Clear();
                
                opResult = "Запитването е изпратено.";
            }

            MainModel viewModel = GetModel(LoadedPage.ContactUs, isAjaxRequest: false);
            viewModel.OperationResult = opResult;

            return View(viewModel);
        }

        public ActionResult SiteMap(MainModel model)
        {
            return View(GetModel(LoadedPage.SiteMap));
        }


        public MainModel GetModel(LoadedPage page, int? typeID = null, bool isAjaxRequest = false)
        {
            MainModel mainModel = new MainModel();

            BMainModel bModel = Main.GetData(page, typeID: typeID, loadCategories: !isAjaxRequest);
            bModel.ExcIfNull();

            mainModel.Categories = bModel.Categories;
            mainModel.Firms = bModel.Firms;
            mainModel.Gallery = bModel.Gallery;
            mainModel.Texts = bModel.Texts;

            mainModel.MailToSent = bModel.MailToSend;

            mainModel.OperationResult = string.Empty;

            return mainModel;
        }

        public void GetPhotoThumbnail(string src, int width, int height)
        {
            src.ExcIfNullOrEmpty();

            WebImage newImg = null;

            string filePath = Request.MapPath(src);
            if (System.IO.File.Exists(filePath))
            {
                newImg = new WebImage(src);
            }
            else
            {
                 newImg = new WebImage(@"~/Resources/Images/Site/no-img.png");
            }

            newImg.Resize(width, height, true, true).Write();
            
        }

    }
}
