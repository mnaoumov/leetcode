namespace LeetCode.Problems._3531_Count_Covered_Buildings;

/// <summary>
/// https://leetcode.com/problems/count-covered-buildings/submissions/1852461973/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCoveredBuildings(int n, int[][] buildings)
    {
        var ysByX = new Dictionary<int, SortedSet<int>>();
        var xsByY = new Dictionary<int, SortedSet<int>>();

        foreach (var building in buildings)
        {
            var x = building[0];
            var y = building[1];

            ysByX.TryAdd(x, new SortedSet<int>());
            ysByX[x].Add(y);

            xsByY.TryAdd(y, new SortedSet<int>());
            xsByY[y].Add(x);
        }

        var ans = 0;

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var building in buildings)
        {
            var x = building[0];
            var y = building[1];

            var ys = ysByX[x];
            var xs = xsByY[y];

            if (ys.Min != y && ys.Max != y && xs.Min != x && xs.Max != x)
            {
                ans++;
            }
        }

        return ans;
    }
}
