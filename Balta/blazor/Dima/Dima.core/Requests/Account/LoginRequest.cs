﻿using System.ComponentModel.DataAnnotations;

namespace Dima.core.Requests.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha inválida")]
        public string Password { get; set; } = string.Empty;
    }
}
