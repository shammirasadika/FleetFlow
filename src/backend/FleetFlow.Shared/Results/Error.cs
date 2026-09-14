namespace FleetFlow.Shared.Results;

/// <summary>A lightweight, structured error used with <see cref="Result"/> and <see cref="Result{TValue}"/>.</summary>
public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static Error NotFound(string code, string message) => new(code, message);

    public static Error Validation(string code, string message) => new(code, message);

    public static Error Conflict(string code, string message) => new(code, message);
}
