using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class CreateOrderEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/create", HandleAsync).WithName("Orders: Create order").WithSummary("Create a order").WithDescription("Create a order").WithOrder(1).Produces<Response<Order?>>();

        private static async Task<IResult> HandleAsync(IOrderHandler handler,CreateOrderRequest request, ClaimsPrincipal user)
        {
            request.UserId = user.Identity!.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSucess ? TypedResults.Created($"v1/orders/{result.Data?.Number}", result) : TypedResults.BadRequest(result);
        }
    }
}
