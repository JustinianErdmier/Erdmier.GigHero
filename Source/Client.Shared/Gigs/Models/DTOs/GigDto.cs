using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

namespace Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;

public sealed record GigDto(GigIdDto Id, string Name, string? WebsiteUrl, Guid UserId, IReadOnlyList<AssignmentIdDto> AssignmentIds)
{
    public static GigDto Create(GigIdDto id, string name, string? websiteUrl, Guid userId, IReadOnlyList<AssignmentIdDto> assignmentIds)
        => new(id, name, websiteUrl, userId, assignmentIds);
}
