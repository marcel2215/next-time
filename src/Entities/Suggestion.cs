using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Suggestion
{
    public Suggestion() { }

    [SetsRequiredMembers]
    public Suggestion(Guid declarationId, DateTimeOffset suggestedTime)
    {
        DeclarationId = declarationId;
        SuggestedTime = suggestedTime;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required Guid DeclarationId { get; set; }

    public Declaration? Declaration { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public required DateTimeOffset SuggestedTime { get; set; }
}
