// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.ComponentModel.DataAnnotations;

using DataLayer;
using ToolsLibrary;
using BusinessLayer.Instruments;

namespace BusinessLayer.BObjects
{
    public class BBaseText
    {
        public int ID { get; set; }
     
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0}то трябва да е между {2} и {1} символа.")]
        [Display(Name = "Заглавие")]
        public string Name { get; set; }

        [Required]
        public TextType Type { get; set; }

        internal BBaseText(Text text)
        {
            text.ExcIfNull();

            this.ID = text.ID;
            this.Name = text.Name;
            this.Type = text.Type.GetTextType();
        }

        public BBaseText() { }
    }

}
