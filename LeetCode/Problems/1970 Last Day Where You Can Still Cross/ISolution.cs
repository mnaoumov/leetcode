using JetBrains.Annotations;

namespace LeetCode._1970_Last_Day_Where_You_Can_Still_Cross;

[PublicAPI]
public interface ISolution
{
    public int LatestDayToCross(int row, int col, int[][] cells);
}
