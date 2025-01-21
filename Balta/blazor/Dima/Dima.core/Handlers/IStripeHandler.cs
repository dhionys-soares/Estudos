using Dima.core.Requests.Stripe;
using Dima.core.Responses;
using Dima.core.Responses.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.core.Handlers
{
    public interface IStripeHandler
    {
        Task<Response<string?>> CreateSessionAsync(CreateSessionRequest request);
        Task<Response<List<StripeTransactionResponse>>> GetTransactionsByOrderNumberAsync(GetTransactionsByOrderNumberRequest request);
    }
}
