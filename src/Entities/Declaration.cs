using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Declaration
{
    public Declaration() { }

    [SetsRequiredMembers]
    public Declaration(Guid meetingId, Guid userId)
    {
        MeetingId = meetingId;
        UserId = userId;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid MeetingId { get; set; }

    public Meeting? Meeting { get; set; }

    public required Guid UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public ICollection<Preference> Preferences { get; } = [];
}
