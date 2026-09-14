namespace FleetFlow.Modules.Identity.Domain;

/// <summary>A tenant company using the FleetFlow platform.</summary>
public class Company
{
    public Guid Id { get; private init; }

    public string Name { get; private set; }

    public DateTime CreatedAt { get; private init; }

    public bool IsActive { get; private set; }

    private Company(Guid id, string name, DateTime createdAt, bool isActive)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        IsActive = isActive;
    }

    public static Company Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return new Company(Guid.NewGuid(), name, DateTime.UtcNow, isActive: true);
    }

    public void Deactivate() => IsActive = false;

    public void Activate() => IsActive = true;

    private Company()
    {
        // Required by EF Core.
        Name = string.Empty;
    }
}
