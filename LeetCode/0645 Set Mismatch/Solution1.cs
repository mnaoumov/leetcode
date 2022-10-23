using JetBrains.Annotations;

namespace LeetCode._0645_Set_Mismatch;

/// <summary>
/// https://leetcode.com/submissions/detail/828241276/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindErrorNums(int[] nums)
    {
        var n = nums.Length;

        var set = Enumerable.Range(1, n).ToHashSet();

        var appearedTwiceNumber = -1;

        foreach (var num in nums)
        {
            if (!set.Remove(num))
            {
                appearedTwiceNumber = num;
            }
        }

        var missingNumber = set.First();

        return new[] { appearedTwiceNumber, missingNumber };
    }
}