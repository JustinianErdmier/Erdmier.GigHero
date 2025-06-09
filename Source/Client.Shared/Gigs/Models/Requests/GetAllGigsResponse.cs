using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;

namespace Erdmier.GigHero.Client.Shared.Gigs.Models.Requests;

public sealed record GetAllGigsResponse(string? ErrorMessage, bool IsSuccess, List<GigDto> Data) : IRequestResponse<List<GigDto>>
{
    public bool HasData => Data.Count > 0;

    public static GetAllGigsResponse Success(List<GigDto> data) => new(ErrorMessage: null, IsSuccess: true, data);

    public static GetAllGigsResponse Failure(string? errorMessage) => new(errorMessage, IsSuccess: false, []);
}
