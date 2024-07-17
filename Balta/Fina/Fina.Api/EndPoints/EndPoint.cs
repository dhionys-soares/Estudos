using Fina.Api.Common;
using Fina.Api.EndPoints.Categories;
using Fina.Api.EndPoints.Transactions;

namespace Fina.Api.EndPoints
{
    public static class EndPoint
    {
        public static void MapEndPoints(this WebApplication app)
        {
            var endPoints = app.MapGroup("/");

            endPoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", ()=> "OK");

            endPoints.MapGroup("v1/categories")
                .WithTags("Categories")
                .MapEndPoint<CreateCategoryEndPoint>()
                .MapEndPoint<UpdateCategoryEndPoint>()
                .MapEndPoint<DeleteCategoryEndPoint>()
                .MapEndPoint<GetCategoryByIdEndPoint>()
                .MapEndPoint<GetAllCategoriesEndPoint>();

            endPoints.MapGroup("v1/transactions")
                .WithTags("Transactions")
                .RequireAuthorization()
                .MapEndPoint<CreateTransactionEndPoint>()
                .MapEndPoint<UpdateTransactionEndPoint>()
                .MapEndPoint<DeleteTransactionEndPoint>()
                .MapEndPoint<GetTransactionByIdEndPoint>()
                .MapEndPoint<GetTransactionsByPeriodEndPoint>();
        }

        private static IEndpointRouteBuilder MapEndPoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndPoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
