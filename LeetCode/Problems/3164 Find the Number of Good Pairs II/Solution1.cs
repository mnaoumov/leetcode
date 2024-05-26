using JetBrains.Annotations;

namespace LeetCode.Problems._3164_Find_the_Number_of_Good_Pairs_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1268035214/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        var num1DividedByKCounts = new Dictionary<int, int>();

        foreach (var num1 in nums1)
        {
            if (num1 % k != 0)
            {
                continue;
            }

            var num1DividedByK = num1 / k;

            num1DividedByKCounts.TryAdd(num1DividedByK, 0);
            num1DividedByKCounts[num1DividedByK]++;
        }

        var num2Counts = nums2.GroupBy(num2 => num2).ToDictionary(g => g.Key, g => g.Count());

        var ans = 0L;

        foreach (var (num1DividedByK, count1) in num1DividedByKCounts)
        {
            foreach (var (num2, count2) in num2Counts)
            {
                if (num1DividedByK % num2 == 0)
                {
                    ans += 1L * count1 * count2;
                }
            }
        }

        return ans;
    }
}
