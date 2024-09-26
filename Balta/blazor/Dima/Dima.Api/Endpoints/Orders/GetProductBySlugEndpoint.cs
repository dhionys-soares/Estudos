using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Orders
{
    public class GetProductBySlugEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{slug}", HandleAsync).WithName("Product: Get product by slug").WithSummary("Get a product by slug").WithDescription("get a product by slug").WithOrder(2).Produces<Response<Product?>>();

        private static async Task<IResult> HandleAsync(IProductHandler handler, string slug)
        {
            var request = new GetProductBySlugRequest
            {
                Slug = slug
            };
            var result = await handler.GetBySlugAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
