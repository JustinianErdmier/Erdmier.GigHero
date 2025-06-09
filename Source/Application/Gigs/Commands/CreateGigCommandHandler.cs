using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Persistence.Contexts;

namespace Erdmier.GigHero.Application.Gigs.Commands;

public sealed class CreateGigCommandHandler : ICommandHandler<CreateGigCommand, Gig?>
{
    private readonly ApplicationDbContext _context;

    public CreateGigCommandHandler(ApplicationDbContext context) => _context = context;

    public async ValueTask<Gig?> Handle(CreateGigCommand command, CancellationToken cancellationToken)
    {
        Gig gig = Gig.Create(command.Name, command.UserId, command.WebsiteUrl);

        _context.Gigs.Add(gig);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);

            return null;
        }

        return gig;
    }
}
