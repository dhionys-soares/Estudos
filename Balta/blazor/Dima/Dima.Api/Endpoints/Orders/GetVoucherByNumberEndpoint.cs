using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;

namespace Dima.Api.Endpoints.Orders
{
    public class GetVoucherByNumberEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{number}", HandleAsync).WithName("Voucher: get voucher by number").WithSummary("get voucher by number").WithDescription("get voucher by number").WithOrder(1).Produces<Response<Voucher?>>();

        private async static Task<IResult> HandleAsync(IVoucherHandler handler, string number)
        {
            var request = new GetVoucherByNumberRequest { Number = number };
            var result = await handler.GetByNumberAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
