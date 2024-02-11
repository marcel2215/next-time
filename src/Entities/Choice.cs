using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Choice
{
    public Choice() { }

    [SetsRequiredMembers]
    public Choice(Guid meetingId, Guid userId)
    {
        MeetingId = meetingId;
        UserId = userId;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid MeetingId { get; init; }

    public Meeting? Meeting { get; set; }

    public required Guid UserId { get; init; }

    public ApplicationUser? User { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public ICollection<Availability> Availabilities { get; } = [];
}
