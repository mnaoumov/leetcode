using JetBrains.Annotations;

namespace LeetCode._0057_Insert_Interval;

[PublicAPI]
public interface ISolution
{
    public int[][] Insert(int[][] intervals, int[] newInterval);
}