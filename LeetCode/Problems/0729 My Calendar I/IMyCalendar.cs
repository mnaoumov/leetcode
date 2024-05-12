using JetBrains.Annotations;

namespace LeetCode.Problems._0729_My_Calendar_I;

[PublicAPI]
public interface IMyCalendar
{
    public bool Book(int start, int end);
}
