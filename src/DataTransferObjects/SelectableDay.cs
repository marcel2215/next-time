using System.Diagnostics.CodeAnalysis;

namespace NextTime.DataTransferObjects;

public sealed class SelectableDay
{
    public SelectableDay() { }

    [SetsRequiredMembers]
    public SelectableDay(DateTimeOffset time)
    {
        Time = time;
    }

    public required DateTimeOffset Time { get; set; }

    public bool IsSelected { get; set; }

    public bool Is8AMSelected { get; set; }

    public bool Is10AMSelected { get; set; }

    public bool Is12PMSelected { get; set; }

    public bool Is4PMSelected { get; set; }

    public bool Is6PMSelected { get; set; }

    public bool Is8PMSelected { get; set; }

    public string FriendlyDate => Time.ToString("dddd, dd MMMM");
}
