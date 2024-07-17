using Fina.Api.Common;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.EndPoints.Transactions
{
    public class GetTransactionsByPeriodEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync)
                .WithName("Transactions: Get All")
                .WithSummary("Recupera todas as transações")
                .WithDescription("Recupera todas as transações")
                .WithOrder(5)
                .Produces<PagedResponse<List<Transaction>?>>();
        }

        private static async Task<IResult> HandleAsync(ItransactionHandler handler, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery] int pageSize = Configuration.DefaultPageSize, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {

            var request = new GetTransactionsByPeriodRequest
            {
                UserId = ApiConfiguration.UserId,
                StartDate = startDate,
                EndDate = endDate,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await handler.GetByPeriodAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
