using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Requests.Reports;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Reports
{
    public class GetIncomesByCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/incomes", HandleAsync);

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IReportHandler handler)
        {
            var request = new GetIncomesByCategoryRequest
            {
                UserId = user.Identity?.Name ?? string.Empty
            };
            var result = await handler.GetIncomesByCategoryReportAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
