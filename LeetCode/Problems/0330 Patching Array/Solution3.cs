namespace LeetCode.Problems._0330_Patching_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1290626878/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinPatches(int[] nums, int n)
    {
        var firstMissing = 1L;
        var ans = 0;
        foreach (var num in nums.Append(int.MaxValue))
        {
            while (firstMissing < Math.Min(0L + num, 1L + n ))
            {
                ans++;
                firstMissing *= 2;
            }

            firstMissing += num;
            if (firstMissing > n)
            {
                return ans;
            }
        }

        throw new InvalidOperationException();
    }
}
