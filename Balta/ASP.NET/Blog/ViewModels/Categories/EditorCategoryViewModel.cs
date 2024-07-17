using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Categories
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage ="O nome é requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage ="O Slug é requerido")]
        public string Slug { get; set; }
    }
}
