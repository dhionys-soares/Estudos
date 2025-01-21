using Dima.Api.Common.Api;
using Dima.Api.Handlers;
using Dima.core.Handlers;
using Dima.core.Requests.Stripe;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Stripe
{
    public class CreateSessionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapPost("/session", HandleAsync).Produces<string?>();

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IStripeHandler handler, CreateSessionRequest request)
        {
            request.UserId = user.Identity!.Name ?? string.Empty;

            var result = await handler.CreateSessionAsync(request);

            return result.IsSucess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
