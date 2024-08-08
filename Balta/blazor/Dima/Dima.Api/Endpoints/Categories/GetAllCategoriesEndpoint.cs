using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.Api.Models;
using Dima.core;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Obtem todas as categorias")
            .WithDescription("Obtem todas as categorias")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category>?>>();

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, [FromServices]ICategoryHandler handler, [FromQuery] int pageSize = Configuration.DefaultPageSize, [FromQuery] int pageNumber = Configuration.DefaultPageNumber)
        {
            var request = new GetAllCategoriesRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);

            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.Ok(result);
        }
    }
}
