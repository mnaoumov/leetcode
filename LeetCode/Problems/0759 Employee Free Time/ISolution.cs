using JetBrains.Annotations;

namespace LeetCode.Problems._0759_Employee_Free_Time;

[PublicAPI]
public interface ISolution
{
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule);
}
