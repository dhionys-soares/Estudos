using Dima.core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dima.core.Requests.Transactions
{
    public class UpdateTransactionRequest : Request
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Título inválido")]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = "Tipo inválido")]
        public ETransactionType Type { get; set; }


        [Required(ErrorMessage = "Quantidade inválida")]
        public decimal Amount { get; set; }


        [Required(ErrorMessage = "Categoria inválida")]
        public long CategoryId { get; set; }


        [Required(ErrorMessage = "Data inválida")]
        public DateTime? PaidOrReceivedAt { get; set; }
    }
}
