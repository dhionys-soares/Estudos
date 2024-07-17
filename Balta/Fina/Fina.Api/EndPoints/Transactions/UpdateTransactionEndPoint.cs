using Fina.Api.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transactions
{
    public class UpdateTransactionEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                .WithName("Transactions: Update")
                .WithSummary("Atualiza uma transação")
                .WithDescription("Atualiza uma transação")
                .WithOrder(2)
                .Produces<Response<Transaction?>>(); ;
        }

        private static async Task<IResult> HandleAsync(ItransactionHandler handler, UpdateTransactionRequest request, long id)
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
