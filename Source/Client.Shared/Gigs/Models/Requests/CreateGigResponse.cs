using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;

namespace Erdmier.GigHero.Client.Shared.Gigs.Models.Requests;

public sealed record CreateGigResponse(string? ErrorMessage, bool IsSuccess, GigDto? Data) : IRequestResponse<GigDto>
{
    public bool HasData => Data is not null;

    public static CreateGigResponse Success(GigDto? data) => new(ErrorMessage: null, IsSuccess: true, data);

    public static CreateGigResponse Failure(string? errorMessage) => new(errorMessage, IsSuccess: false, Data: null);
}
