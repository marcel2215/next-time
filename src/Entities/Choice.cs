using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Choice
{
    public Choice() { }

    [SetsRequiredMembers]
    public Choice(Guid appointmentId)
    {
        AppointmentId = appointmentId;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid AppointmentId { get; init; }

    public Appointment Appointment { get; init; } = default!;

    public required Guid UserId { get; init; }

    public ApplicationUser? User { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public ICollection<Availability> Availabilities { get; } = [];
}
