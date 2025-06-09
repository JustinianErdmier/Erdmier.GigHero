using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed class GetGigByIdQueryHandler : IQueryHandler<GetGigByIdQuery, Gig?>
{
    private readonly ApplicationDbContext _context;

    public GetGigByIdQueryHandler(ApplicationDbContext context) => _context = context;

    public async ValueTask<Gig?> Handle(GetGigByIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Gigs.FirstOrDefaultAsync(g => g.Id == query.Id, cancellationToken);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return null;
        }
    }
}
