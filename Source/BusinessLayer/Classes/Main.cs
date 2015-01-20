// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;

using DataLayer;
using BusinessLayer.BObjects;
using BusinessLayer.Instruments;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    /// <summary>
    /// Loads the information needed for displaying on the selected page.
    /// </summary>
    public class Main
    {
        /// <param name="typeID"> For categories: the chosen category; For Admin page: the selected text for edit;</param>
        /// <param name="loadCategories">If it should load the categories for the menu. Must be true if the page is not loaded
        /// via AJAX request, otherwise false, because the categories are not going to be refreshed anyway </param>
        public static BMainModel GetData(LoadedPage page, int? typeID = null, bool loadCategories = true)
        {
            BMainModel model = null;

            switch (page)
            {
                case LoadedPage.AboutUs:
                    model = LoadDataForAboutUsPage(loadCategories);
                    break;
                case LoadedPage.Categories:
                    model = LoadDataForCategoriesPage(loadCategories, typeID: typeID);
                    break;
                case LoadedPage.Firms:
                    model = LoadDataForFirmsPage(loadCategories);
                    break;
                case LoadedPage.Promotions:
                    model = LoadDataForPromotionsPage(loadCategories);
                    break;
                case LoadedPage.Services:
                    model = LoadDataForServicesPage(loadCategories);
                    break;
                case LoadedPage.Admin:
                    model = LoadDataForAdminPage(typeID);
                    break;
                case LoadedPage.ContactUs:
                    model = LoadDataForContactUsPage(loadCategories);
                    break;
                case LoadedPage.SiteMap:
                    model = LoadDataForSiteMapPage();
                    break;
                default:
                    BTools.NewBException(string.Format("Страница '{0}' не се поддържа за зареждане на информация от бизнес слоя.", page));
                    break;
            }

            model.ExcIfNull();

            return model;
        }

        private static BMainModel LoadDataForAdminPage(int? selectedTextID = null)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                List<BBaseText> textsToEdit = null;
                BText selectedText = null;
                Texts.GetTexts(trModel, ref textsToEdit, ref selectedText, selectedTextID);

                model.TextToUpdate = selectedText;
                model.TextsToEdit = textsToEdit;
            }

            return model;
        }

        private static BMainModel LoadDataForAboutUsPage(bool loadCategories)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                if (loadCategories == true)
                {
                    model.Categories = Categories.GetCategories(trModel);
                }
               
                model.Gallery = Images.GetImages(trModel, ImageType.Store);
            }

            return model;
        }

        private static BMainModel LoadDataForCategoriesPage(bool loadCategories, int? typeID = null)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                model.Categories = Categories.GetCategoriesWithProducts(trModel, loadCategories, typeID);
            }

            return model;
        }

        private static BMainModel LoadDataForFirmsPage(bool loadCategories)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                if (loadCategories == true)
                {
                    model.Categories = Categories.GetCategories(trModel);
                }
               
                model.Firms = Firms.GetFirms(trModel, true);
            }

            return model;
        }

        private static BMainModel LoadDataForPromotionsPage(bool loadCategories)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                if (loadCategories == true)
                {
                    model.Categories = Categories.GetCategories(trModel);
                }
                
                model.Texts = Texts.GetTextsForPage(trModel, LoadedPage.Promotions);
            }

            return model;
        }

        private static BMainModel LoadDataForServicesPage(bool loadCategories)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                if (loadCategories == true)
                {
                    model.Categories = Categories.GetCategories(trModel);
                }
            }

            return model;
        }

        private static BMainModel LoadDataForContactUsPage(bool loadCategories)
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                if (loadCategories == true)
                {
                    model.Categories = Categories.GetCategories(trModel);
                }
                
                model.MailToSend = new BMail();
            }

            return model;
        }

        private static BMainModel LoadDataForSiteMapPage()
        {
            BMainModel model = new BMainModel();

            using (TrucksReserveEntities trModel = new TrucksReserveEntities())
            {
                model.Categories = Categories.GetCategories(trModel);
            }

            return model;
        }

    }
}
