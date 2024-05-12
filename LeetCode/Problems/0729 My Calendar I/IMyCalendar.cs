using JetBrains.Annotations;

namespace LeetCode._0729_My_Calendar_I;

[PublicAPI]
public interface IMyCalendar
{
    public bool Book(int start, int end);
}
