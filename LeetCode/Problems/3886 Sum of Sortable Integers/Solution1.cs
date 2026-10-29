namespace LeetCode.Problems._3886_Sum_of_Sortable_Integers;

/// <summary>
/// https://leetcode.com/problems/sum-of-sortable-integers/submissions/2177505373/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int SortableIntegers(int[] nums)
    {
        var n = nums.Length;

        var sorted = nums.OrderBy(x => x).ToArray();

        var ans = 0;

        for (var k = 1; k <= n; k++)
        {
            if (n % k != 0)
            {
                continue;
            }

            var isSortable = true;

            for (var i = 0; i < n; i += k)
            {
                var indices = Enumerable.Range(i, k).ToArray();
                var unsortedStr = string.Concat(indices.Select(j => $"<{nums[j]}>"));
                var sortedStr = string.Concat(indices.Select(j => $"<{sorted[j]}>"));

                if ((sortedStr + sortedStr).Contains(unsortedStr, StringComparison.Ordinal))
                {
                    continue;
                }

                isSortable = false;
                break;
            }


            if (isSortable)
            {
                ans += k;
            }
        }


        return ans;
    }
}
