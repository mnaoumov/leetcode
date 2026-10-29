namespace LeetCode.Problems._3768_Minimum_Inversion_Count_in_Subarrays_of_Fixed_Length;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-171/problems/minimum-inversion-count-in-subarrays-of-fixed-length/submissions/1848499405/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinInversionCount(int[] nums, int k)
    {
        var list = new List<(int num, int index)>();

        var inversionCount = 0;

        for (var i = 0; i < k; i++)
        {
            var key = (nums[i], i);
            var index = ~list.BinarySearch(key);
            list.Insert(index, key);
            inversionCount += list.Count - 1 - index;
        }

        var ans = inversionCount;

        for (var j = k; j < nums.Length; j++)
        {
            var keyToRemove = (nums[j - k], j - k);
            var removeIndex = list.BinarySearch(keyToRemove);
            inversionCount -= removeIndex;
            list.RemoveAt(removeIndex);
            var keyToAdd = (nums[j], j);
            var addIndex = ~list.BinarySearch(keyToAdd);
            list.Insert(addIndex, keyToAdd);
            inversionCount += list.Count - 1 - addIndex;
            ans = Math.Min(ans, inversionCount);
        }

        return ans;
    }
}
