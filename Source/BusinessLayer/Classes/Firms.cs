// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Collections.Generic;
using System.Linq;

using DataLayer;
using BusinessLayer.BObjects;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    internal class Firms
    {
        public static List<BFirm> GetFirms(TrucksReserveEntities dc, bool loadImages)
        {
            dc.ExcIfNull();

            List<BFirm> firms = new List<BFirm>();

            List<Firm> dbFirms = dc.Firms.ToList();
            if (dbFirms.AreThereItems() == true)
            {
                firms = dbFirms.ConvertAll<BFirm>(new Converter<Firm, BFirm>(BFirm.ElementConverter));

                if (loadImages == true)
                {
                    List<Gallery> dbFirmsImages = dc.Gallery.Where(g => g.Type == (int)ImageType.Firm).ToList();
                    if (dbFirmsImages.AreThereItems() == true)
                    {
                        List<Gallery> firmImages = new List<Gallery>();
                        foreach (BFirm firm in firms)
                        {
                            firmImages = dbFirmsImages.Where(i => i.TypeID.HasValue == true && i.TypeID == firm.ID).ToList();
                            if (firmImages.AreThereItems() == true)
                            {
                                firm.Images = firmImages.ConvertAll<BImage>(new Converter<Gallery, BImage>(BImage.ElementConverter));
                            }
                        }
                    }
                }
            }

            return firms;
        }
    }
}
