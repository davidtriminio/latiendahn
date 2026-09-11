namespace latiendahn.BuildingBlocks.Results;

public enum ErrorType { Failure = 0, Validation = 1, Unauthorized = 2, Forbidden = 3, NotFound = 4, Conflict = 5 }

/// <summary>Un fallo esperado y de dominio, con un codigo estable para el cliente.</summary>
public sealed record Error(string Code, string Message, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    public static Error Validation(string code, string message) => new(code, message, ErrorType.Validation);
    public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);
    public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);
    public static Error Unauthorized(string code, string message) => new(code, message, ErrorType.Unauthorized);
    public static Error Forbidden(string code, string message) => new(code, message, ErrorType.Forbidden);
}