namespace LeetCode.Problems._2285_Maximum_Total_Importance_of_Roads;

/// <summary>
/// https://leetcode.com/submissions/detail/1302439826/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumImportance(int n, int[][] roads)
    {
        var counts = new int[n];

        foreach (var road in roads)
        {
            var a = road[0];
            var b = road[1];
            counts[a]++;
            counts[b]++;
        }

        Array.Sort(counts);

        return Enumerable.Range(0, n).Select(i => 1L * counts[i] * (i + 1)).Sum();
    }
}
