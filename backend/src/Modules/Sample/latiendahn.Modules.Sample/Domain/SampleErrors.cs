using latiendahn.BuildingBlocks.Results;

namespace latiendahn.Modules.Sample.Domain;

public static class SampleErrors
{
    public static readonly Error NotFound = Error.NotFound("sample.not_found", "El item no existe.");
    public static Error NameInUse(string name) => Error.Conflict("sample.name_in_use", $"Ya existe un item llamado '{name}'.");
}