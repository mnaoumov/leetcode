using JetBrains.Annotations;

namespace LeetCode._2857_Count_Pairs_of_Points_With_Distance_k;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-113/submissions/detail/1051021949/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPairs(IList<IList<int>> coordinates, int k)
    {
        var pairCounts = new Dictionary<(int x, int y), int>();
        var ans = 0;

        foreach (var coordinate in coordinates)
        {
            var pair = (x: coordinate[0], y: coordinate[1]);

            for (var i = 0; i <= k; i++)
            {
                var otherPair = (pair.x ^ i, pair.y ^ k - i);
                ans += pairCounts.GetValueOrDefault(otherPair);
            }

            pairCounts.TryAdd(pair, 0);
            pairCounts[pair]++;
        }

        return ans;
    }
}
