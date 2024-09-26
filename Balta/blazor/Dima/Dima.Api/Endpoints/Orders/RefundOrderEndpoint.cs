using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class RefundOrderEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}/refund", HandleAsync).WithName("Order: refund an order").WithSummary("refund an order").WithDescription("refund an order").WithOrder(6).Produces<Response<Order?>>();

        private async static Task<IResult> HandleAsync(IOrderHandler handler, long id, ClaimsPrincipal user)
        {
            var request = new RefundOrderRequest { Id = id, UserId = user.Identity!.Name ?? string.Empty };
            var result = await handler.RefundAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
