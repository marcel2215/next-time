namespace NextTime.Enums;

[Flags]
public enum PartOfDay
{
    None = 0,
    Night = 1,
    Morning = 2,
    Afternoon = 4,
    Evening = 8,
    All = Night | Morning | Afternoon | Evening
}
