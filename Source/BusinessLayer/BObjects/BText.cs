// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using DataLayer;

namespace BusinessLayer.BObjects
{
    public class BText : BBaseText
    {
        [AllowHtml] 
        [StringLength(10000, MinimumLength = 0, ErrorMessage = "Описанието (със стиловете за визуализация) не трябва да надвишава {1} символа.")]
        public string Description { get; set; }

        internal BText(Text text)
            : base(text)
        {
            this.Description = text.Description;
        }

        public BText() : base() 
        {
            this.Description = string.Empty;
        }
    }
}
