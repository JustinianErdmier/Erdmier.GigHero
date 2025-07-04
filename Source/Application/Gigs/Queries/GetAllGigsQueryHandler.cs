﻿using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed class GetAllGigsQueryHandler : IQueryHandler<GetAllGigsQuery, List<Gig>>
{
    private readonly ApplicationDbContext _context;

    public GetAllGigsQueryHandler(ApplicationDbContext context) => _context = context;

    public async ValueTask<List<Gig>> Handle(GetAllGigsQuery query, CancellationToken cancellationToken)
    {
        List<Gig> gigs = [];

        try
        {
            gigs = await _context.Gigs.Where(g => g.UserId == query.UserId)
                                 .ToListAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return gigs;
        }

        return gigs;
    }
}
