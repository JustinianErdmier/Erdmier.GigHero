namespace Erdmier.GigHero.Client.Contracts.Gigs.Models.DTOs;

public sealed record GigIdDto(Guid Value)
{
    public static GigIdDto Create(Guid value) => new(value);
}
