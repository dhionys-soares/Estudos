using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Accounts
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage ="imagem inválida")]
        public string Base64Image { get; set; }
    }
}
