using JetBrains.Annotations;

namespace LeetCode.Problems._0456_132_Pattern;

/// <summary>
/// https://leetcode.com/submissions/detail/950401344/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool Find132pattern(int[] nums)
    {
        var minMaxMap = new Dictionary<int, int>();
        var sortedMins = new SortedSet<int>();

        foreach (var num in nums)
        {
            var mins = sortedMins.GetViewBetween(int.MinValue, num - 1);

            if (mins.Count == 0)
            {
                sortedMins.Add(num);
                minMaxMap[num] = num;
            }
            else
            {
                foreach (var min in mins)
                {
                    if (minMaxMap[min] > num)
                    {
                        return true;
                    }

                    minMaxMap[min] = num;
                }
            }
        }

        return false;
    }
}
