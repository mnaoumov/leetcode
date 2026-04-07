namespace LeetCode.Problems._3852_Smallest_Pair_With_Different_Frequencies;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-177/problems/smallest-pair-with-different-frequencies/submissions/1933705055/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MinDistinctFreqPair(int[] nums)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

        var sorted = counts.Keys.OrderBy(x => x).ToArray();
        var x = sorted[0];

        foreach (var y in sorted.Skip(1))
        {
            if (counts[x] == counts[y])
            {
                continue;
            }

            return new[] { x, y };
        }

        return new[] { -1, -1 };
    }
}
