using Erdmier.GigHero.Domain.Common.Errors;
using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Persistence.Contexts;

using ErrorOr;

using Microsoft.EntityFrameworkCore;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed class GetGigByIdQueryHandler : IQueryHandler<GetGigByIdQuery, ErrorOr<Gig>>
{
    private readonly ApplicationDbContext _context;

    public GetGigByIdQueryHandler(ApplicationDbContext context) => _context = context;

    public async ValueTask<ErrorOr<Gig>> Handle(GetGigByIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            Gig? gig = await _context.Gigs.FirstOrDefaultAsync(g => g.Id == query.Id, cancellationToken);

            return gig is null ? Errors.Gig.NotFound(query.Id) : gig;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return Error.Unexpected();
        }
    }
}
