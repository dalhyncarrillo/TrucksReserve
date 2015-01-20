// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;

namespace BusinessLayer.BObjects
{
    /// <summary>
    /// Analogous to TrucksReserve.Models, which is handled to the user interface with the filled in data
    /// </summary>
    public class BMainModel
    {
        public List<BCategory> Categories { get; set; }
        public List<BProduct> Products { get; set; }
        public List<BFirm> Firms { get; set; }
        public List<BImage> Gallery { get; set; }
        public List<BText> Texts { get; set; }

        /// <summary>
        /// When page different than the administrator one is shown: the text, which needs to be shown on the page (About Us, Contacts, Promotions, Services).
        /// When admin page is shown: The text, which is selected for modify
        /// </summary>
        public BText TextToUpdate { get; set; }
        public List<BBaseText> TextsToEdit { get; set; }

        public BMail MailToSend { get; set; }

        public BMainModel() { }
    }
}
