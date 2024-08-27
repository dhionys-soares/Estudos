using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models.Reports;
using Dima.core.Requests.Reports;
using Dima.core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Reports
{
    public class GetIncomesAndExpensesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/incomes-expenses", HandleAsync).Produces<Response<List<IncomesAndExpenses>?>>();
        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IReportHandler handler)
        {
            var request = new GetIncomesAndExpensesRequest
            {
                UserId = user.Identity?.Name ?? string.Empty
            };
            var result = await handler.GetIncomesAndExpensesReportAsync(request);
            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
