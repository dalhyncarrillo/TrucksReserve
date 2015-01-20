﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Web;
using System.Web.Optimization;

namespace TrucksReserve
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/MainJs").Include(
                "~/Scripts/JQuery/jquery-{version}.js"
                , "~/Scripts/SiteScripts.js"
                , "~/Scripts/imgpreview.full.jquery.js"
                , "~/Scripts/bjqs-{version}.js"
                , "~/Scripts/pixastic.custom.js"
                , "~/Scripts/JQuery/jquery.unobtrusive*"
                , "~/Scripts/JQuery/jquery.validate*"
                , "~/Scripts/highslide/highslide.js"
                , "~/Scripts/highslide/highslide.config.js"
                ));

            bundles.Add(new StyleBundle("~/Content/MainCss").Include(
                "~/Content/Master.css"
                , "~/Content/Header.css"
                , "~/Content/Menu.css"
                , "~/Content/Body.css"
                , "~/Content/Categories.css"
                , "~/Content/Firms.css"
                , "~/Content/Index.css"
                , "~/Content/bjqs.css"
                , "~/Content/Services.css"
                , "~/Content/Promotions.css"
                , "~/Content/ContactUs.css"
                , "~/Scripts/highslide/highslide.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/AdminJs").Include(
               "~/Scripts/JQuery/jquery-{version}.js"
               , "~/Scripts/JQuery/jquery.unobtrusive*"
               , "~/Scripts/JQuery/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/AdminCss").Include());

            ///Allows optimizations for debug
            //BundleTable.EnableOptimizations = true;
        }
    }
}