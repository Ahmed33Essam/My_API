﻿using System.ComponentModel.DataAnnotations;

namespace My_API.DTO
{
    public class LoginDTO
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
