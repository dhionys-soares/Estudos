using Fina.Api.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Transactions
{
    public class DeleteTransactionEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync)
                .WithName("Transactions: Delete")
                .WithSummary("Deleta uma transação")
                .WithDescription("Deleta uma transação")
                .WithOrder(3)
                .Produces<Response<Transaction?>>(); ;
        }

        private static async Task<IResult> HandleAsync(ItransactionHandler handler, long id)
        {
            var request = new DeleteTransactionRequest 
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
