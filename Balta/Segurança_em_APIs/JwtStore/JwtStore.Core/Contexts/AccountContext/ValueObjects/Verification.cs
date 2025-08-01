﻿using JwtStore.Core.Contexts.SharedContext.ValueObjetcs;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects;

public class Verification : ValueObject
{
    public Verification()
    {
    }

    public string Code { get;} = Guid.NewGuid().ToString("N")[..6].ToUpper();
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
    public DateTime? VerifiedAt { get; private set; } = null;
    public bool IsActive => VerifiedAt != null && ExpiresAt == null;

    public void Verify(string code)
    {
        if (IsActive)
            throw new Exception("este item já foi ativado");

        if (ExpiresAt < DateTime.UtcNow)
            throw new Exception("Este código já expirou");

        if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
        {
            throw new Exception("Este código de verificação é inválido");
        }
    }
}