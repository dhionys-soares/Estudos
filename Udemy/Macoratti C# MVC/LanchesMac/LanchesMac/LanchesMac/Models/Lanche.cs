using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{

    [Table("Lanches")]
    public class Lanche
    {

        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {80} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O descriçao do lanche deve ser informada")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "A descrição deve ter no mínimo 1 caracter")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder 200 caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O descriçao detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "A descrição detalhada deve ter no mínimo 1 caracter")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada não pode exceder 200 caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999.99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho imagem normal")]
        [StringLength(200, ErrorMessage = "O caminho deve conter no máximo, 200 caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho da imagem miniatura")]
        [StringLength(200, ErrorMessage = "O caminho deve conter no máximo, 200 caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
