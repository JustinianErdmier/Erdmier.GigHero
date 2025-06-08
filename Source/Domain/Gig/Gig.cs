namespace Erdmier.GigHero.Domain.Gig;

public sealed class Gig : AggregateRoot<GigId, Guid>
{
    private readonly List<AssignmentId> _assignmentIds = [];

    private Gig()
    { }

    private Gig(string name, Guid userId, string? website, GigId? id = null)
        : base(id ?? GigId.CreateUnique())
    {
        Name    = name;
        UserId  = userId;
        Website = website;
    }

    public IReadOnlyList<AssignmentId> AssignmentIds => _assignmentIds.AsReadOnly();

    public string Name { get; private set; } = null!;

    public Guid UserId { get; init; }

    public string? Website { get; private set; }

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

    public void UpdateWebsite(string website) => Website = website;

    public static Gig Create(string name, Guid userId, string? website) => new(name, userId, website);
}
