﻿using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id:long}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Deleta uma categoria")
            .WithDescription("Deleta uma categoria")
            .WithOrder(3)
            .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync([FromServices]ICategoryHandler handler,[FromRoute] long id)
        {
            var request = new DeleteCategoryRequest
            {
                Id = id,
                UserId = "dhi.soares@hotmail.com"
            };

            var result = await handler.DeleteAsync(request);

            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}