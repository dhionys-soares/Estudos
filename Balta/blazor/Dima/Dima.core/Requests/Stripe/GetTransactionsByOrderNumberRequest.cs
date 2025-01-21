using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.core.Requests.Stripe
{
    public class GetTransactionsByOrderNumberRequest : Request
    {
        public string Number { get; set; } = string.Empty;
    }
}
