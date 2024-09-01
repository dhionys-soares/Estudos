using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;

namespace Dima.core.Handlers
{
    public interface IOrderHandler
    {
        Task<Response<Order?>> CancelAsync(CancelOrderRequest request);
        Task<Response<Order?>> CreateAsync(CreateOrderRequest request);
        Task<Response<Order?>> PayAsync(PayOrderRequest request);
        Task<Response<Order?>> RefundAsync(RefundOrderRequest request);
        Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request);
        Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request);
    }
}
