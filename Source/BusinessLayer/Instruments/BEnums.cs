// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

namespace BusinessLayer
{
    public enum ImageType : int
    {
        Unknown = 0,
        Product = 1,
        Category = 2,
        Firm = 3,
        Store = 4
    }

    public enum LoadedPage : int
    {
        AboutUs = 1,
        Categories = 2,
        Firms = 3,
        Services = 4,
        Promotions = 5,
        Admin = 6,
        ContactUs = 7,
        SiteMap
    }

    public enum TextType : int
    {
        Unknown = 0,
        AboutUs = 1,
        ContactUs = 2,
        Services = 3,
        Promotions = 4
    }

}
