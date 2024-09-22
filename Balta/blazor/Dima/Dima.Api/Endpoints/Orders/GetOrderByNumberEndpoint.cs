using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class GetOrderByNumberEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/{number}", HandleAsync).WithName("Order: Get by order").WithSummary("Get a order").WithDescription("Get a order").WithOrder(6).Produces<Response<Order?>>();

        private static async Task<IResult> HandleAsync(IOrderHandler handler, string number, ClaimsPrincipal user)
        {
            var request = new GetOrderByNumberRequest { UserId = user.Identity!.Name ?? string.Empty, Number = number };
            var result = await handler.GetByNumberAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
