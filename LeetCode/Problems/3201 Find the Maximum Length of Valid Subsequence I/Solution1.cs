using JetBrains.Annotations;

namespace LeetCode.Problems._3201_Find_the_Maximum_Length_of_Valid_Subsequence_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-404/submissions/detail/1304384890/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumLength(int[] nums)
    {
        var evenCount = nums.Count(x => x % 2 == 0);
        var oddCount = nums.Length - evenCount;

        var alternateCount = 1;
        var mod = nums[0] % 2;

        foreach (var num in nums)
        {
            if (num % 2 == mod)
            {
                continue;
            }

            alternateCount++;
            mod = num % 2;
        }

        return new[] { evenCount, oddCount, alternateCount }.Max();
    }
}
