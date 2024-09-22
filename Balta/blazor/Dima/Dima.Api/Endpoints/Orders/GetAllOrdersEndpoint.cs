using Dima.Api.Common.Api;
using Dima.core;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class GetAllOrdersEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync).WithName("Orders: Get orders").WithSummary("Get orders").WithDescription("Get orders").WithOrder(5).Produces<PagedResponse<List<Order>?>>();

        private static async Task<IResult> HandleAsync(IOrderHandler handler, ClaimsPrincipal user, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllOrdersRequest {UserId = user.Identity!.Name ?? string.Empty, PageNumber = pageNumber, PageSize = pageSize};
            var result = await handler.GetAllAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
