﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.ComponentModel.DataAnnotations;

namespace TrucksReserve.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        [StringLength(100, MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Парола")]
        [StringLength(100, MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
        }
    }
}