using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class CancelOrderEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/{id}/cancel", HandleAsync).WithName("Orders: Cancel order").WithSummary("Cancel a order").WithDescription("Cancel a order").WithOrder(2).Produces<Response<Order?>>();

        private static async Task<IResult> HandleAsync(IOrderHandler handler, long id,ClaimsPrincipal user)
        {
            var request = new CancelOrderRequest { Id = id, UserId = user.Identity!.Name ?? string.Empty };
            var result = await handler.CancelAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
