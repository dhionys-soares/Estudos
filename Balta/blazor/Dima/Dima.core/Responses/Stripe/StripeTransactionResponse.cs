using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.core.Responses.Stripe
{
    public class StripeTransactionResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long Amount { get; set; }
        public long AmountCaptured { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool Paid { get; set; }
        public bool Refunded { get; set; }
    }
}
