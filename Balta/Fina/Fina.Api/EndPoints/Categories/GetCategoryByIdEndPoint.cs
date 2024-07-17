using Fina.Api.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.EndPoints.Categories
{
    public class GetCategoryByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync)
                .WithName("Categories: Get By Id")
                .WithSummary("Recupera uma categoria")
                .WithDescription("Recupera uma categoria")
                .WithOrder(4)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(ICategoryHandler handler,long id)
        {
            var request = new GetCategoryByIdRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };
            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
