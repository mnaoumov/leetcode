namespace LeetCode.Problems._0846_Hand_of_Straights;

/// <summary>
/// https://leetcode.com/submissions/detail/1278957773/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length < groupSize * groupSize)
        {
            return false;
        }

        var counts = hand.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        if (counts.Count < groupSize)
        {
            return false;
        }

        var sorted = counts.Keys.OrderBy(x => x).ToArray();

        var groupsLeft = groupSize;

        for (var i = 0; i < sorted.Length; i++)
        {
            if (sorted.Length - i < groupsLeft)
            {
                return false;
            }

            var min = sorted[i];

            if (!counts.ContainsKey(min))
            {
                continue;
            }

            var isValidGroup = true;

            for (var j = 0; j < groupSize; j++)
            {
                var num = min + j;

                if (counts.ContainsKey(num))
                {
                    continue;
                }

                isValidGroup = false;
                break;
            }

            if (!isValidGroup)
            {
                continue;
            }

            groupsLeft--;

            if (groupsLeft == 0)
            {
                return true;
            }

            for (var j = 0; j < groupSize; j++)
            {
                var num = min + j;
                counts[num]--;

                if (counts[num] > 0)
                {
                    continue;
                }

                counts.Remove(num);
            }
        }

        return false;
    }
}
