using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Meeting
{
    public Meeting() { }

    [SetsRequiredMembers]
    public Meeting(Guid ownerId, string title)
    {
        OwnerId = ownerId;
        Title = title;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid OwnerId { get; set; }

    public ApplicationUser? Owner { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public TimeSpan Duration { get; set; } = TimeSpan.FromHours(1);

    public ICollection<Declaration> Declarations { get; } = [];
}
