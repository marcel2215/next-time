using System.Diagnostics.CodeAnalysis;
using NextTime.Utilities;

namespace NextTime.Entities;

public sealed class Meeting
{
    public Meeting() { }

    [SetsRequiredMembers]
    public Meeting(Guid userId, string title)
    {
        UserId = userId;
        Title = title;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public required string Title { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Code { get; set; } = RandomGenerator.GenerateMeetingCode();

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public TimeSpan Duration { get; set; } = TimeSpan.FromHours(1);

    public ICollection<Preference> Preferences { get; } = [];
}
