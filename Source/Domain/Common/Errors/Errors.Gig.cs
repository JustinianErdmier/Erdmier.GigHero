using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

using ErrorOr;

namespace Erdmier.GigHero.Domain.Common.Errors;

public static partial class Errors
{
    public static class Gig
    {
        public static Error NotFound(GigId id) => Error.NotFound($"{nameof(Gig)}.{nameof(NotFound)}", $"{nameof(Gig)} with id {id} not found.");

        public static Error NotUnique(string name) => Error.Validation($"{nameof(Gig)}.{nameof(NotUnique)}", $"{nameof(Gig)} with named {name} already exists.");
    }
}
