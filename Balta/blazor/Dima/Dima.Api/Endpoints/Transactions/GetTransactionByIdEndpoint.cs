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
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id:long}", HandleAsync).WithName("Transactions: GetById")
            .WithSummary("Obtem uma transação por Id")
            .WithDescription("Obtem uma transação por Id")
            .WithOrder(4)
            .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, [FromServices]ITransactionHandler handler,[FromRoute] long id)
        {
            var request = new GetTransactionByIdRequest
            {
                Id = id,
                UserId = user.Identity?.Name ?? string.Empty
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}