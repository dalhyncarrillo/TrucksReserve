// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Collections.Generic;
using System.Linq;

using DataLayer;
using ToolsLibrary;

namespace BusinessLayer.BObjects
{
    public class BFirm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

        public List<BImage> Images { get; set; }

        public BFirm(Firm firm)
        {
            SetProperties(firm, null);
        }

        public BFirm(Firm firm, TrucksReserveEntities dbModel)
        {
            dbModel.ExcIfNull();

            SetProperties(firm, dbModel);
        }

        private void SetProperties(Firm firm, TrucksReserveEntities dbModel)
        {
            firm.ExcIfNull();

            this.ID = firm.ID;
            this.Name = firm.Name;
            this.Description = firm.Description.GetTrimmed();
            this.Website = firm.Website.GetTrimmed();

            Images = new List<BImage>();
            if (dbModel != null)
            {
                List<Gallery> images = dbModel.Gallery.Where(i => i.Type == (int)ImageType.Firm && i.TypeID == firm.ID).ToList();
                if (images.AreThereItems() == true)
                {
                    this.Images = images.ConvertAll<BImage>(new Converter<Gallery, BImage>(BImage.ElementConverter));
                }
            }
        }

        internal static BFirm ElementConverter(Firm firm)
        {
            return new BFirm(firm);
        }

    }
}
