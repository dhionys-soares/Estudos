using Dima.core.Handlers;
using Dima.core.Requests.Stripe;
using Dima.core.Responses;
using Dima.core.Responses.Stripe;
using System.Net.Http.Json;

namespace Dima.Web.Handlers
{
    public class StripeHandler(IHttpClientFactory httpClientFactory) : IStripeHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<string?>> CreateSessionAsync(CreateSessionRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/payments/stripe/session", request);
            return await result.Content.ReadFromJsonAsync<Response<string?>>() ?? new Response<string?>(null, 400, "Não foi possível criar sessão");
        }

        public async Task<Response<List<StripeTransactionResponse>>> GetTransactionsByOrderNumberAsync(GetTransactionsByOrderNumberRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/payments/stripe/{request.Number}/transactions", request);
            return await result.Content.ReadFromJsonAsync<Response<List<StripeTransactionResponse>>>() ?? new Response<List<StripeTransactionResponse>>(null, 400, "Não foi possível obter as transações");
        }
    }
}
