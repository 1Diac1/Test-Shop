﻿using System.ComponentModel.DataAnnotations;

namespace Test_Shop.Application.Common.Models.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
