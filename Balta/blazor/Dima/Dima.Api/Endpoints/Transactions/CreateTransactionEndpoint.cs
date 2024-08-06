using Dima.Api.Common.Api;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Transactions;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Transaction: Cria uma nova transação")
                .WithSummary("cria uma nova transação")
                .WithDescription("cria uma nova transação")
                .WithOrder(1)
                .Produces<Response<Transaction?>>();
        


        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler,[FromBody] CreateTransactionRequest request)
        {
            request.UserId = "dhi.soares@hotmail.com";
            var result = await handler.CreateAsync(request);
            return result.IsSucess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
