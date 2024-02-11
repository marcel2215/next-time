using Microsoft.AspNetCore.Identity;

namespace NextTime.Exceptions;

public sealed class IdentityException : Exception
{
    public IdentityException() : base() { }

    public IdentityException(string message) : base(message) { }

    public IdentityException(string message, Exception innerException) : base(message, innerException) { }

    public IdentityException(string? code, string? description) : base($"An unexpected identity error occurred '{code ?? "N/A"}': '{description ?? "N/A"}'.") { }

    public IdentityException(IdentityResult result) : base($"An unexpected identity error occurred '{result.Errors.FirstOrDefault()?.Code ?? "N/A"}': '{result.Errors.FirstOrDefault()?.Description ?? "N/A"}'.") { }
}
