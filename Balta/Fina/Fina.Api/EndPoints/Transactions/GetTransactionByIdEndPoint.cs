using Fina.Api.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transactions
{
    public class GetTransactionByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync)
                .WithName("Transactions: Get By Id")
                .WithSummary("Recupera uma transação")
                .WithDescription("Recupera uma transação")
                .WithOrder(4)
                .Produces<Response<Transaction?>>();
        }

        private static async Task<IResult> HandleAsync(ItransactionHandler handler, long id)
        {

            var request = new GetTransactionByIdRequest
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
