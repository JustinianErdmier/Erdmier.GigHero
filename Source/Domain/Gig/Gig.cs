namespace Erdmier.GigHero.Domain.Gig;

public sealed class Gig : AggregateRoot<GigId, Guid>
{
    private readonly List<JobId> _jobIds = [];

    private Gig()
    { }

    private Gig(string name, Guid userId, string? website, GigId? id = null)
        : base(id ?? GigId.CreateUnique())
    {
        Name    = name;
        UserId  = userId;
        Website = website;
    }

    public IReadOnlyList<JobId> JobIds => _jobIds.AsReadOnly();

    public string Name { get; private set; } = null!;

    public Guid UserId { get; init; }

    public string? Website { get; private set; }

    public bool AddJobId(JobId jobId)
    {
        if (_jobIds.Contains(jobId))
        {
            return false;
        }

        _jobIds.Add(jobId);

        return true;
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateWebsite(string website) => Website = website;

    public static Gig Create(string name, Guid userId, string? website) => new(name, userId, website);
}
