using Fina.Api.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories
{
    public class UpdateCategoryEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                .WithName("Categories: Update")
                .WithSummary("Atualiza uma categoria")
                .WithDescription("Atualiza uma categoria")
                .WithOrder(2)
                .Produces<Response<Category?>>();
        }

        private static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryRequest request, long id)
        {
            request.UserId = ApiConfiguration.UserId;
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
