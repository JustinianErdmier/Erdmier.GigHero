namespace Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;

public sealed record GigIdDto(Guid Value)
{
    public static GigIdDto Create(Guid value) => new(value);
}
