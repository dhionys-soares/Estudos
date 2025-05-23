﻿using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers
{
    public class OrderHandler(IHttpClientFactory httpClientFactory) : IOrderHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Order?>> CancelAsync(CancelOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/cancel", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>() ?? new Response<Order?>(null, 400, "não foi possível cancelar o pedido");
        }

        public async Task<Response<Order?>> CreateAsync(CreateOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/orders/create", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>() ?? new Response<Order?>(null, 400, "não foi possível criar o pedido");
        }

        public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Order>?>>("v1/orders") ?? new PagedResponse<List<Order>?>(null, 400, "não foi possível obter os pedidos");

        public async Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request)
        => await _client.GetFromJsonAsync<Response<Order?>>($"v1/orders/{request.Number}") ?? new Response<Order?>(null, 400, "não foi possível obter o pedido");

        public async Task<Response<Order?>> PayAsync(PayOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/pay", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>() ?? new Response<Order?>(null, 400, "não foi possível pagar o pedido");
        }

        public async Task<Response<Order?>> RefundAsync(RefundOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/refund", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>() ?? new Response<Order?>(null, 400, "não foi possível estornar o pedido");
        }
    }
}
