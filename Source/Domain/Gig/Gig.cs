namespace Erdmier.GigHero.Domain.Gig;

public sealed class Gig : AggregateRoot<GigId, Guid>
{
    private readonly List<AssignmentId> _assignmentIds = [];

    private Gig()
    { }

    private Gig(string name, Guid userId, string? websiteUrl, GigId? id = null)
        : base(id ?? GigId.CreateUnique())
    {
        Name       = name;
        UserId     = userId;
        WebsiteUrl = websiteUrl;
    }

    public IReadOnlyList<AssignmentId> AssignmentIds => _assignmentIds.AsReadOnly();

    public string Name { get; private set; } = null!;

    public Guid UserId { get; init; }

    public string? WebsiteUrl { get; private set; }

    public bool AddAssignmentId(AssignmentId assignmentId)
    {
        if (_assignmentIds.Contains(assignmentId))
        {
            return false;
        }

        _assignmentIds.Add(assignmentId);

        return true;
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateWebsiteUrl(string url) => WebsiteUrl = url;

    public static Gig Create(string name, Guid userId, string? websiteUrl) => new(name, userId, websiteUrl);

    public static Gig CreateFromDto(GigId id, string name, Guid userId, string? websiteUrl, IReadOnlyList<AssignmentId> assignmentIds)
    {
        Gig gig = new(name, userId, websiteUrl, id);

        foreach (AssignmentId assignmentId in assignmentIds)
        {
            gig.AddAssignmentId(assignmentId);
        }

        return gig;
    }
}
