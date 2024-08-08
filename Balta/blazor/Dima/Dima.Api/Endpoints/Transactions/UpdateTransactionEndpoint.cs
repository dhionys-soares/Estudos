using Dima.Api.Common.Api;
using Dima.Api.Models;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Transactions;
using Dima.core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id:long}", HandleAsync)
                .WithName("Transaction: Atualiza uma transação")
                .WithSummary("Atualiza uma transação")
                .WithDescription("Atualiza uma transação")
                .WithOrder(3)
                .Produces<Response<Transaction?>>();
        

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, [FromServices]ITransactionHandler handler,[FromBody] UpdateTransactionRequest request,[FromRoute] long id)
        {
            request.Id = id;
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.UpdateAsync(request);

            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
