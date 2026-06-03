namespace LeetCode.Problems._1674_Minimum_Moves_to_Make_Array_Complementary;

/// <summary>
/// https://leetcode.com/problems/minimum-moves-to-make-array-complementary/submissions/2002508259/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMoves(int[] nums, int limit)
    {
        var n = nums.Length;

        var diffs = new int[2 * limit + 2];

        for (var i = 0; i < n / 2; i++)
        {
            var a = nums[i];
            var b = nums[n - 1 - i];

            if (a > b)
            {
                (a, b) = (b, a);
            }

            diffs[2] += 2;
            diffs[a + 1]--;
            diffs[a + b]--;
            diffs[a + b + 1]++;
            diffs[b + limit + 1]++;
        }

        var ans = n;
        var ops = 0;

        for (var c = 2; c <= 2 * limit; c++)
        {
            ops += diffs[c];
            ans = Math.Min(ans, ops);
        }

        return ans;
    }
}
