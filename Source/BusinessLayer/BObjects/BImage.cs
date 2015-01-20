// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using DataLayer;
using ToolsLibrary;
using BusinessLayer.Instruments;

namespace BusinessLayer.BObjects
{
    public class BImage
    {
        public int ID { get; set; }
        public ImageType Type { get; set; }
        public int? TypeID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool Main { get; set; }

        public string FullPathWithTilde { get { return ("~" + FullPath); } }
        public string FullPath { get { return (this.FilePath + this.FileName); } }

        public BImage(Gallery image)
        {
            image.ExcIfNull();

            this.Type = image.Type.GetImageType();
            this.TypeID = image.TypeID;
            this.FileName = image.FileName;
            this.FilePath = image.FilePath;
            this.Main = image.Main;
        }

        public static BImage ElementConverter(Gallery image)
        {
            return new BImage(image);
        }
    }
}
