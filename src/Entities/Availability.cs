using System.Diagnostics.CodeAnalysis;
using NextTime.Enums;

namespace NextTime.Entities;

public sealed class Availability
{
    public Availability() { }

    [SetsRequiredMembers]
    public Availability(Guid declarationId, DateTimeOffset startTime, DateTimeOffset endTime, PartOfDay partOfDay = PartOfDay.All)
    {
        DeclarationId = declarationId;
        StartTime = startTime;
        EndTime = endTime;
        PartOfDay = partOfDay;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid DeclarationId { get; set; }

    public Declaration? Declaration { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public required DateTimeOffset StartTime { get; set; }

    public required DateTimeOffset EndTime { get; set; }

    public PartOfDay PartOfDay { get; set; } = PartOfDay.All;
}
