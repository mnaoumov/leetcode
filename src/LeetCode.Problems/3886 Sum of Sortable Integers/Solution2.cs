namespace LeetCode.Problems._3886_Sum_of_Sortable_Integers;

/// <summary>
/// https://leetcode.com/problems/sum-of-sortable-integers/submissions/2177509542/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SortableIntegers(int[] nums)
    {
        var n = nums.Length;

        var sorted = nums.OrderBy(x => x).ToArray();

        var isSorted = sorted.SequenceEqual(nums);

        var ans = 0;

        var sqrt = (int) Math.Sqrt(n);

        for (var k = 1; k <= sqrt; k++)
        {
            if (n % k != 0)
            {
                continue;
            }

            if (IsSortable(k))
            {
                ans += k;
            }

            var l = n / k;

            if (l != k && IsSortable(l))
            {
                ans += l;
            }
        }


        return ans;

        bool IsSortable(int k)
        {
            var isSortable = true;

            if (!isSorted)
            {
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
            }

            return isSortable;
        }
    }
}
