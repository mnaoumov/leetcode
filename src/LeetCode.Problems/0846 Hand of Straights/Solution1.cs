namespace LeetCode.Problems._0846_Hand_of_Straights;

/// <summary>
/// https://leetcode.com/submissions/detail/1278957773/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length != groupSize * groupSize)
        {
            return false;
        }

        var counts = hand.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var sorted = new SortedSet<int>(counts.Keys);

        for (var i = 0; i < groupSize; i++)
        {
            var min = sorted.Min;

            for (var j = 0; j < groupSize; j++)
            {
                var num = min + j;

                if (!counts.ContainsKey(num))
                {
                    return false;
                }

                counts[num]--;

                if (counts[num] > 0)
                {
                    continue;
                }

                counts.Remove(num);
                sorted.Remove(num);
            }
        }

        return true;
    }
}
