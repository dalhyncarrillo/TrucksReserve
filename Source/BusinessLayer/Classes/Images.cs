// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Collections.Generic;
using System.Linq;

using DataLayer;
using BusinessLayer.BObjects;
using BusinessLayer.Instruments;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    internal class Images
    {
        public static List<BImage> GetImages(TrucksReserveEntities trModel, ImageType type, int? typeID = null)
        {
            trModel.ExcIfNull();
            if (type == ImageType.Unknown) { BTools.NewBException(string.Format("Снимки тип '{0}' не се поддържат за зареждане от базата.", type)); }

            List<Gallery> dbImages = trModel.Gallery.Where(i => i.Type == (int)type 
                && (typeID.HasValue == false || (i.TypeID.HasValue == true && i.TypeID.Value == typeID.Value))).ToList();

            List<BImage> images = new List<BImage>();
            if (dbImages.AreThereItems() == true)
            {
                images = dbImages.ConvertAll<BImage>(new Converter<Gallery, BImage>(BImage.ElementConverter));
            }

            return images;
        }

    }
}
