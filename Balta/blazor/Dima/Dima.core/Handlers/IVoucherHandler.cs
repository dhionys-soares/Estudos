using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;

namespace Dima.core.Handlers
{
    public interface IVoucherHandler
    {
        Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request);
    }
}
