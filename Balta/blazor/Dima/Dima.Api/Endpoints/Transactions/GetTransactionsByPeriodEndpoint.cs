using Dima.Api.Common.Api;
using Dima.core;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Transactions;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionsByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync).WithName("Transactions: GetByPeriod")
            .WithSummary("Obtem transações por período")
            .WithDescription("Obtem transações por período")
            .WithOrder(5)
            .Produces<PagedResponse<List<Transaction>?>>();
        

        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery]int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetTransactionsByPeriodRequest
            {
                UserId = "dhi.soares@hotmail.com",
                PageNumber = pageNumber,
                PageSize = pageSize,
                StartDate = startDate,
                EndDate = endDate
            };
            
            var result = await handler.GetByPeriodAsync(request);

            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
