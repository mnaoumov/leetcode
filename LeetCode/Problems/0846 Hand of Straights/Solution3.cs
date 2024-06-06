using JetBrains.Annotations;

namespace LeetCode.Problems._0846_Hand_of_Straights;

/// <summary>
/// https://leetcode.com/submissions/detail/1278969549/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
        {
            return false;
        }

        var counts = hand.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var sorted = new SortedSet<int>(counts.Keys);

        while (sorted.Count > 0)
        {
            var min = sorted.Min;

            for (var j = 0; j < groupSize; j++)
            {
                var num = min + j;

                if (!counts.TryGetValue(num, out var count))
                {
                    return false;
                }

                if (count > 1)
                {
                    counts[num] = count - 1;
                    continue;
                }

                counts.Remove(num);
                sorted.Remove(num);
            }
        }

        return true;
    }
}
