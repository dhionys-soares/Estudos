using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.SharedContext.Entities;

namespace JwtStore.Core.AccountContext.Entities;

public class User : Entity
{
    public Email Email { get; set; }
}