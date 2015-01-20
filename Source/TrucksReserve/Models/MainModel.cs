﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;

using BusinessLayer.BObjects;

namespace TrucksReserve.Models
{
    public class MainModel
    {
        public List<BCategory> Categories { get; set; }
        public List<BFirm> Firms { get; set; }
        public List<BImage> Gallery { get; set; }
        public List<BText> Texts { get; set; }

        public BMail MailToSent { get; set; }

        /// <summary>
        /// The sent email result from contacts form 
        /// </summary>
        public string OperationResult { get; set; }
    }
}
