﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

using TrucksReserve.Instruments;
using BusinessLayer.Classes;
using ToolsLibrary;

namespace TrucksReserve
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LoadCustomConfigurations();
        }

        private void LoadCustomConfigurations()
        {
            string siteContactMail = global :: TrucksReserve.Properties.Settings.Default.SiteContactMail;
            siteContactMail.ExcIfNullOrEmpty();
            if (siteContactMail.IsValidEmailAddress() == false) { UiTools.NewUiException("invalid SiteContactMail"); }
            Mail.SiteContactMail = siteContactMail;

            Mail.SendMailViaSSL = global :: TrucksReserve.Properties.Settings.Default.SendMailsViaSSL;
        }

        
    }
}