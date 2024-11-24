using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Dima.Web.Handlers
{
    public class VoucherHandler(IHttpClientFactory httpClientFactory) : IVoucherHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request)
            => await _client.GetFromJsonAsync<Response<Voucher?>>($"v1/vouchers/{request.Number}") ?? new Response<Voucher?>(null, 400, "Não foi possível obter o voucher");
        
    }
}
