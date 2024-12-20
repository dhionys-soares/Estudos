﻿using Dima.Api.Common.Api;
using Dima.core.Models.Account;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Identity
{
    public class GetRolesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/roles", Handle).RequireAuthorization();
        }

        private static Task<IResult> Handle(ClaimsPrincipal user)
        {
            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Task.FromResult(Results.Unauthorized());

            var identity = user.Identity as ClaimsIdentity;
            var roles = identity?.FindAll(identity.RoleClaimType).Select(x => new RoleClaim
            {
                Issuer = x.Issuer,
                OriginalIssuer = x.OriginalIssuer,
                Type = x.Type,
                Value = x.Value,
                ValueType = x.ValueType
            });

            return Task.FromResult<IResult>(TypedResults.Json(roles));
        }
    }
}
