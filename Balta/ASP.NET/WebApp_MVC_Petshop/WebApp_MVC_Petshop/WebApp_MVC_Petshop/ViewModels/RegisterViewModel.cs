using System.ComponentModel.DataAnnotations;

namespace WebApp_MVC_Petshop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O Nome é necessário")]
        [MinLength(3, ErrorMessage = "Digite ao menos 3 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="O Email é necessário")]
        [EmailAddress(ErrorMessage ="Digite um email válido")]
        [MaxLength(30, ErrorMessage ="Digite no máximo 30 caracteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="A senha é neecessária")]
        [MaxLength(50, ErrorMessage ="Digite no máximo 50 caracteres")]
        public string PasswordHash { get; set; }
    }
}
