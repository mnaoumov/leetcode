namespace LeetCode._0031_Next_Permutation;

/// <summary>
/// https://leetcode.com/submissions/detail/812403685/
/// </summary>
public class Solution5 : ISolution
{
    public void NextPermutation(int[] nums)
    {
        var lastIndexWithIncrease = nums.Length - 2;
        while (lastIndexWithIncrease >= 0 && nums[lastIndexWithIncrease] >= nums[lastIndexWithIncrease + 1])
        {
            lastIndexWithIncrease--;
        }

        if (lastIndexWithIncrease == -1)
        {
            Array.Sort(nums);
            return;
        }

        var nextPair = nums.Select((num, index) => (num, index)).Where(pair => pair.num > nums[lastIndexWithIncrease] && pair.index > lastIndexWithIncrease)
            .MinBy(pair => pair.num);
        (nums[lastIndexWithIncrease], nums[nextPair.index]) = (nextPair.num, nums[lastIndexWithIncrease]);
        Array.Sort(nums, lastIndexWithIncrease + 1, nums.Length - lastIndexWithIncrease - 1);
    }
}