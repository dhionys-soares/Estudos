using Dima.Api.Common.Api;
using Dima.core;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Orders
{
    public class GetAllProductsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync).WithName("Products: Get products").WithSummary("Get products").WithDescription("Get products").WithOrder(4).Produces<PagedResponse<List<Product>?>>();

        private static async Task<IResult> HandleAsync(IProductHandler handler, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllProductsRequest { PageNumber = pageNumber, PageSize = pageSize };
            var result = await handler.GetAllAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
