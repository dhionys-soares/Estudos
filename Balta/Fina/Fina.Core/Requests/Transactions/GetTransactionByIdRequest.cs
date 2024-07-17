using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Transactions
{
    public class GetTransactionByIdRequest : Request
    {
        [Required(ErrorMessage = "Id é necessário")]
        public long Id { get; set; }
    }
}
