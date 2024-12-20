﻿using Fina.Api.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories
{
    public class DeleteCategoryEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync)
                .WithName("Categories: Delete")
                .WithSummary("Exclui uma categoria")
                .WithDescription("Exclui uma categoria")
                .WithOrder(3)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
        {
            var request = new DeleteCategoryRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
