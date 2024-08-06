using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Transactions;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) 
            => app.MapDelete("/{id:long}", HandleAsync)
                .WithName("Transaction: Deleta uma transação")
                .WithSummary("deleta uma transação")
                .WithDescription("deleta uma transação")
                .WithOrder(2)
                .Produces<Response<Transaction?>>();
        

        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler,[FromRoute] long id)
        {
            var request = new DeleteTransactionRequest
            {
                Id = id,
                UserId = "dhi.soares@hotmail.com"
            };

            var result = await handler.DeleteAsync(request);
            
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
