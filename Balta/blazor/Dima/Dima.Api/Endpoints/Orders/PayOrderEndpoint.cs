using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class PayOrderEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/{id}/pay", HandleAsync).WithName("Order: Pay an order").WithSummary("pay an order").WithDescription("pay an order").WithOrder(3).Produces<Response<Order?>>();

        private async static Task<IResult> HandleAsync(IOrderHandler handler, ClaimsPrincipal user, long id, PayOrderRequest request)
        {
            request.UserId = user.Identity!.Name ?? string.Empty;
            request.Id = id;
            var result = await handler.PayAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
