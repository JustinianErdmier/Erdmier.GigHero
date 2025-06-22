using ErrorOr;

namespace Erdmier.GigHero.Domain.Common.Errors;

public static partial class Errors
{
    public static class Assignment
    {
        public static Error NotFound(AssignmentId id) => Error.NotFound($"{nameof(Assignment)}.{nameof(NotFound)}", $"{nameof(Assignment)} with id {id} not found.");
    }
}
