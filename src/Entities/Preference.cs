using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Preference
{
    public Preference() { }

    [SetsRequiredMembers]
    public Preference(Guid meetingId, Guid userId, DateTimeOffset time)
    {
        MeetingId = meetingId;
        UserId = userId;
        PreferredTime = time;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid MeetingId { get; set; }

    public Meeting? Meeting { get; set; }

    public required Guid UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public required DateTimeOffset PreferredTime { get; set; }
}
