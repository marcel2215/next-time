using System.Diagnostics.CodeAnalysis;
using NextTime.Enums;

namespace NextTime.Entities;

public sealed class Availability
{
    public Availability() { }

    [SetsRequiredMembers]
    public Availability(Guid choiceId, DateTimeOffset startTime, DateTimeOffset endTime, PartOfDay dayParts = PartOfDay.All)
    {
        ChoiceId = choiceId;
        StartTime = startTime;
        EndTime = endTime;
        DayParts = dayParts;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid ChoiceId { get; init; }

    public Choice? Choice { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public required DateTimeOffset StartTime { get; set; }

    public required DateTimeOffset EndTime { get; set; }

    public PartOfDay DayParts { get; set; } = PartOfDay.All;
}
