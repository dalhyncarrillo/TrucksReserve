// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.BObjects
{
    public class BMail
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "***")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "***")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "***")]
        public string PersonEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "***")]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "***")]
        public string Message { get; set; }

        public BMail() 
        {
            this.PersonEmail = string.Empty;
            this.Message = string.Empty;
        }
    }
}
