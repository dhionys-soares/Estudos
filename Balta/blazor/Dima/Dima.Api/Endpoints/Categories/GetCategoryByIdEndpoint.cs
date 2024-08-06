using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: GetById")
            .WithSummary("Obtem uma categoria por Id")
            .WithDescription("Obtem uma categoria por Id")
            .WithOrder(4)
            .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync([FromServices]ICategoryHandler handler,[FromRoute] long id)
        {
            var request = new GetCategoryByIdRequest
            {
                Id = id,
                UserId = "dhi.soares@hotmail.com"
            };
            var result = await handler.GetByIdAsync(request);

            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.Ok(result.Data);
        }
    }
}
