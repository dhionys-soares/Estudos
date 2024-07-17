﻿using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Accounts
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o email")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        
        public string Email { get; set; }

        [Required(ErrorMessage ="informe a senha")]
        
        public string Password { get; set; }
    }
}
