using System.Diagnostics.CodeAnalysis;

namespace NextTime.DataTransferObjects;

public sealed class SelectableDay
{
    private bool _isSelected;
    private bool _is8AMSelected;
    private bool _is10AMSelected;
    private bool _is12PMSelected;
    private bool _is4PMSelected;
    private bool _is6PMSelected;
    private bool _is8PMSelected;

    public SelectableDay() { }

    [SetsRequiredMembers]
    public SelectableDay(DateTimeOffset time)
    {
        Time = time;
    }

    public required DateTimeOffset Time { get; set; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool Is8AMSelected
    {
        get => _is8AMSelected;
        set
        {
            _is8AMSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool Is10AMSelected
    {
        get => _is10AMSelected;
        set
        {
            _is10AMSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool Is12PMSelected
    {
        get => _is12PMSelected;
        set
        {
            _is12PMSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool Is4PMSelected
    {
        get => _is4PMSelected;
        set
        {
            _is4PMSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool Is6PMSelected
    {
        get => _is6PMSelected;
        set
        {
            _is6PMSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool Is8PMSelected
    {
        get => _is8PMSelected;
        set
        {
            _is8PMSelected = value;
            IsLastActionSelect = value;
        }
    }

    public bool IsLastActionSelect { get; set; } = true;

    public string FriendlyDate => Time.ToString("dddd, dd MMMM");
}
